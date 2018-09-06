using AccessManager.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

        public object Login(string token)
        {
            //session login
            if (/*validate user*/ false)
            {
                //return response (set cookie, redirect)
                string url = HomeController.RedirectUrl;
            }
            return null;
        }

        public object Login(User user)
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