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
            return SSOServer.Instance.ValidateToken(token);
        }
        /*
        [HttpGet]
        [Route("login")]
        public HttpResponseMessage Login(string redirect)
        {
            //get token from cookie
            string token = string.Empty;
            if (null != HttpContext.Current.Request.Cookies["token"])
            {
                token = HttpContext.Current.Request.Cookies["token"].Value;
            }

            return SSOServer.Instance.Login(token, HomeController.RedirectUrl);
        }*/

        [HttpPost]
        [Route("login")]
        public HttpResponseMessage Login(User user)
        {
            //return SSOServer.Instance.Login(user, HomeController.RedirectUrl);

            string token = Identify.Valid(user);
            if (!string.IsNullOrWhiteSpace(token))
            {
                HttpContext.Current.Response.Cookies.Add(new HttpCookie("token", token));

                var response = Request.CreateResponse(HttpStatusCode.Redirect);
                response.Headers.Location = new Uri(HomeController.RedirectUrl + "?token=" + token);
                //response.Headers.Add("Access-Control-Allow-Origin", "*");
                return response;
            }
            return null;
        }
    }
}