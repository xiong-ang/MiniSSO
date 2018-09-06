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
            RedirectUrl = redirect;

            return View();
        }
    }
}
