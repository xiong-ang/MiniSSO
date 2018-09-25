using AccessManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccessManager.Controllers
{
    public class HomeController : Controller
    {
        public static string RedirectUrl;
        public ActionResult Index(string redirect)
        {
            if(!string.IsNullOrWhiteSpace(redirect))
            {
                RedirectUrl = redirect;
                string token = Request.Cookies["token"] == null ? string.Empty : Request.Cookies["token"].Value;
                if (!string.IsNullOrWhiteSpace(token) && !string.IsNullOrWhiteSpace(Identify.Valid(token)))
                {
                    string redirectUrl = HomeController.RedirectUrl + "?token=" + token;
                    return Redirect(redirectUrl);
                }
            }

            return View();
        }
    }
}
