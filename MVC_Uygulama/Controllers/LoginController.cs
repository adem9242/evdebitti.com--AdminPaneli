using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC_Uygulama.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GirisYap()
        {
            return View();
        }


        [HttpPost]
        public ActionResult GirisYap(string email,string sifre,string hatirla)
        {
           bool durum= Membership.ValidateUser(email, sifre);
           if (durum == true)
           {
               if (hatirla == "on")
               {
                   FormsAuthentication.RedirectFromLoginPage(email, true);
               }
               else
               {
                   FormsAuthentication.RedirectFromLoginPage(email, false);
               }

               return RedirectToAction("Index", "Home");
           }
           else
           {
               ViewBag.mesaj = "Kullanıcı adı veya şifre hatalı.";
           }



           return View();
        }
    }
}