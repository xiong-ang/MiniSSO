using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SomeClient.Models
{
    public class SSOClient
    {
        #region sington
        private SSOClient() { }

        private static object _sLock = new object();
        private static SSOClient _instance;
        public static SSOClient Instance
        {
            get
            {
                lock (_sLock)
	            {
		            return null == _instance ? _instance = new SSOClient() : _instance;
	            }
            }
        }
        #endregion sington

        #region public methods
        public bool IsValidToken(string token)
        {
            return false;
        }

        public void RedirectToAM()
        {

        }
        #endregion public methods

    }
}