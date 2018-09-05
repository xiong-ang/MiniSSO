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

        #region public methods
        public bool ValidateToken(string token)
        {
            return false;
        }

        public bool ValidateUser()
        {
            return false;
        }
        #endregion public methods
    }
}