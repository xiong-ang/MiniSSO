using Jose;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace AccessManager.Models
{
    public class Identify
    {
        private static Dictionary<string, string> _identities = new Dictionary<string, string>
        {
            {"xiong.ang@foxmail.com", "123456"},
            {"axiong3@ra.rockwell.com", "123456"}
        };

        private static byte[] secretKey = new byte[] { 164, 60, 194, 0, 161, 189, 41, 38, 130, 89, 141, 164, 45, 170, 159, 209, 69, 137, 243, 216, 191, 131, 47, 250, 32, 107, 231, 117, 37, 158, 225, 234 };

        private static DateTime tokenAcquiredTime;

        public static string Valid(User user)
        {
            if (!string.Equals(user.password, _identities[user.email]))
                return string.Empty;

            var payload = new Dictionary<string, object>()
            {
                { "email", user.email },
                { "exp", 1300819380 }
            };

            tokenAcquiredTime = DateTime.Now;
            return Jose.JWT.Encode(payload, secretKey, JwsAlgorithm.HS256);
        }

        public static string Valid(string token)
        {
            string json;
            try
            {
                json = Jose.JWT.Decode(token, secretKey);
            }
            catch (Exception)
            {
                return string.Empty;
            }

            TokenInfo tokenInfo = JsonConvert.DeserializeObject<TokenInfo>(json);

            if (_identities.Keys.Contains(tokenInfo.email))
            {
                //TODO: verify time
                if (DateTime.Now < tokenAcquiredTime.AddMilliseconds(int.Parse(tokenInfo.exp) - 5 * 60*1000)) ;
                {
                    return token;
                }
            }
            return string.Empty;
        }
    }

    public class TokenInfo
    {
        public string email;
        public string exp;
    }
}