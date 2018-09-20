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
        public ActionResult Index(string token)
        {
            if(string.IsNullOrWhiteSpace(token) && null != Request.Cookies["token"])
            {
                //Get token from cookie
                token = Request.Cookies["token"].Value;
            }

            string amUrl = "http://localhost:44444?redirect=http://localhost:55555";
            if (!SSOClient.Instance.IsValidToken(token))
                return Redirect(amUrl);


            //Set token to cookie
            HttpCookie cookie = new HttpCookie("token", token);
            Response.Cookies.Add(cookie);
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            Response.Headers.Add("Access-Control-Allow-Methods", "OPTIONS,POST,GET");
            Response.Headers.Add("Access-Control-Allow-Headers", "x-auth-token,Origin,Access-Token,X-Requested-With,Content-Type, Accept");
            return View();
        }
    }
}

/*
Cookie的存储
 * 
1. Response.Cookies["Cookie的名称"].Value=变量值；
 * 
2. HttpCookie cookie=new HttpCookie("Cookie名称","值");  
   Response.Cookies.Add(cookie);
 * 
3.HttpCookie cookie=new HttpCookie("Cookie名称");  
  cookie.Value="值";  
  Response.Cookies.Add(cookie);
 * 
 * 
 * 
读取Cookie方法
 * 
if(Request.Cookies["UserName"]!=null)  
{  
    string username=Request.Cookies("UserName").Value;  
} 
 */
