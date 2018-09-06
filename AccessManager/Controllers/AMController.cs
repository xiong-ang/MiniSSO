using AccessManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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
        public object Login()
        {
            string token = string.Empty;
            //get token from cookie

            return SSOServer.Instance.Login(token);
        }

        [HttpPost]
        [Route("login")]
        public object Login([FromBody]User user)
        {
            return SSOServer.Instance.Login(user);
        }
    }

    public class User
    {
        public string email;
        public string password;
    }
}
