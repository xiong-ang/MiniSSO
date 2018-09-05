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

        [HttpPost]
        [Route("login")]
        public void Login([FromBody]string value)
        {
            //username, password login
            //session login
            if(SSOServer.Instance.ValidateUser())
            {
                //return response (set cookie, redirect)
            }
        }
    }
}
