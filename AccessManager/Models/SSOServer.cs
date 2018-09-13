using AccessManager.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace AccessManager.Models
{
    public class SSOServer
    {
        #region sington
        private SSOServer() { }

        private static object _sLock = new object();
        private static SSOServer _instance;
        public static SSOServer Instance 
        { 
            get 
            {
                lock (_sLock)
                {
                    return null == _instance ? _instance = new SSOServer() : _instance;
                }
            } 
        }
        #endregion sington

        #region public interfaces
        public bool ValidateToken(string token)
        {
            return false;
        }

        public HttpResponseMessage Login(string token, string redirect)
        {
            //session login
            if (!string.IsNullOrWhiteSpace(token))
            {
                HttpContext.Current.Response.Cookies.Add(new HttpCookie("token", token));
                //return response (set cookie, redirect)
                string url = HomeController.RedirectUrl+"?token="+token;

                HttpContext.Current.Response.Redirect(url);
                return null;
            }
            return null;
        }

        /*public HttpResponseMessage Login(User user, string redirect)
        {
            string token = Identify.Valid(user);
            if (!string.IsNullOrWhiteSpace(token))
            {
                HttpContext.Current.Response.Cookies.Add(new HttpCookie("token", token));
                //return response (set cookie, redirect)
                string url = HomeController.RedirectUrl+"?token="+token;

                var response = Request.CreateResponse(HttpStatusCode.Found);
                response.Headers.Location = new Uri("http://www.google.com");
                return response;
            }
            return null;
        }*/

        public void Logout()
        {
            //Clear user session
        }
        #endregion public interfaces
    }
}


/*
 * How to redirect in web api
public HttpResponseMessage Get()
{
    var response = Request.CreateResponse(HttpStatusCode.Found);
    response.Headers.Location = new Uri("http://www.google.com");
    return response;
}
*/