using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SomeClient.Models
{
    class AjaxHelper
    {
        //High level get method
        public static bool GetCall(string UriLink, out string answer)
        {
            answer = string.Empty;
            using (var request = new HttpRequestMessage())
            {
                request.RequestUri = new Uri(UriLink);
                request.Method = HttpMethod.Get;

                //Add some special info
                //request.Headers.Add..

                return SendCall(request, out answer);
            }
        }

        //High level post method
        public static bool PostCall(string UriLink, string content, out string answer)
        {
            answer = string.Empty;
            using (var request = new HttpRequestMessage())
            {
                request.RequestUri = new Uri(UriLink);
                request.Method = HttpMethod.Post;

                //Add some special info
                //request.Headers.Add..

                request.Content = new StringContent(content, Encoding.UTF8, "application/json");
                return SendCall(request, out answer);
            }
        }

        //Low level request method
        public static bool SendCall(HttpRequestMessage req, out string answer)
        {
            //To Add Common Header Info, such as : Token, Client_id, Client_secret
            //req.Headers.Add...  

            answer = string.Empty;
            HttpResponseMessage res = null;
            if(SendCall(req, out res))
            {
                answer = res.Content.ReadAsStringAsync().Result;
                return true;
            }
            return false;
        }

        //Low level request method
        public static bool SendCall(HttpRequestMessage req, out HttpResponseMessage res)
        {
            res = null;
            try
            {
                using (var client = new HttpClient())
                {
                    res = client.SendAsync(req, HttpCompletionOption.ResponseContentRead).Result;
                    return res.IsSuccessStatusCode;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}