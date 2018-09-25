using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SomeClient.Models
{
    public class SSOClient
    {
        #region sington
        private SSOClient() { }

        private static object _sLock = new object();
        private static SSOClient _instance;
        public static SSOClient Instance
        {
            get
            {
                lock (_sLock)
	            {
		            return null == _instance ? _instance = new SSOClient() : _instance;
	            }
            }
        }
        #endregion sington

        #region public interface
        public bool IsValidToken(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                return false;

            string answer = string.Empty;
            AjaxHelper.GetCall("http://localhost:44444/am/validate?token=" + token, out answer);

            return string.Equals(answer, "true", StringComparison.OrdinalIgnoreCase);
        }

        public void Logout()
        {
            //Call AM logout
        }
        #endregion public interface

    }
}