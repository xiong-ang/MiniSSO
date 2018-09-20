using AccessManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.Web.Http.Results;

namespace AccessManager.Controllers
{
    [RoutePrefix("am")]
    public class AMController : ApiController
    {
        [HttpGet]
        [Route("validate")]
        public bool Validate(string token)
        {
            //Todo: Use client token policy
            return !string.IsNullOrWhiteSpace(Identify.Valid(token));
        }

        //Cross Domain
        //https://cloud.tencent.com/developer/article/1335420
        [HttpPost]
        [Route("login")]
        public string Login(User user)
        {
            string token = Identify.Valid(user);
            if (!string.IsNullOrWhiteSpace(token))
            {
                HttpContext.Current.Response.Cookies.Add(new HttpCookie("token", token));

                string redirectUrl = HomeController.RedirectUrl + "?token=" + token;
                return redirectUrl;      
            }
            return string.Empty;
        }
    }
}