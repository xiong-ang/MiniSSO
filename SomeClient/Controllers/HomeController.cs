using SomeClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SomeClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string token = string.Empty;
            //Get token from cookie

            if (!SSOClient.Instance.IsValidToken(token))
                SSOClient.Instance.RedirectToAM();

            ViewBag.Title = "Home Page";
            return View();
        }
    }
}
