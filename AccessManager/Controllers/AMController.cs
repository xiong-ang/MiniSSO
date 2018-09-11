using AccessManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;

namespace AccessManager.Controllers
{
    [RoutePrefix("am")]
    public class AMController : ApiController
    {
        [HttpGet]
        [Route("validate")]
        public bool Validate(string token)
        {
            return SSOServer.Instance.ValidateToken(token);
        }

        [HttpGet]
        [Route("login")]
        public IHttpActionResult Login(string redirect)
        {
            //get token from cookie
            string token = string.Empty;
            if (null != HttpContext.Current.Request.Cookies["token"])
            {
                token = HttpContext.Current.Request.Cookies["token"].Value;
            }

            return SSOServer.Instance.Login(token, redirect);
        }

        [HttpPost]
        [Route("login")]
        public IHttpActionResult Login([FromBody]User user, [FromUri] string redirect)
        {
            //set token to cookie
            return SSOServer.Instance.Login(user, redirect);
        }
    }

    public class User
    {
        public string email;
        public string password;
    }
}