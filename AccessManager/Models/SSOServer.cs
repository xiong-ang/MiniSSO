using AccessManager.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IHttpActionResult Login(string token, string redirect)
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

        public IHttpActionResult Login(User user, string redirect)
        {
            //username, password login
            if (/*validate user*/ false)
            {
                //return response (set cookie, redirect)
                string url = HomeController.RedirectUrl;
            }
            return null;
        }

        public void Logout()
        {
            //Clear user session
        }
        #endregion public interfaces
    }
}