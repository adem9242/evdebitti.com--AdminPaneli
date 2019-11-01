using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace MVC_Uygulama.Controllers
{
    //[Authorize]
    public class UyeController : Controller
    {
        // GET: Uye
        public ActionResult Index()
        {

            MembershipUserCollection user = Membership.GetAllUsers();

            return View(user);
        }
        
        public ActionResult UyeEkle()
        {
            return View();

        }
        [HttpPost]
        public ActionResult UyeEkle(string kullaniciadi,string sifre,string email ,string gsoru,string gcevap)
        {
            MembershipCreateStatus durum;
            Membership.CreateUser(kullaniciadi, sifre, email, gsoru, gcevap, true, out durum);
            string mesaj = "";
         

            switch (durum)
            {
                case MembershipCreateStatus.Success:

                    break;
                case MembershipCreateStatus.InvalidUserName:
                    mesaj += "adınızı hatalı";
                    break;
                case MembershipCreateStatus.InvalidPassword:
                    mesaj += "sifre hatalı";
                    break;
                case MembershipCreateStatus.InvalidQuestion:
                    mesaj += "cevap boş bırakama";
                    break;
                case MembershipCreateStatus.InvalidAnswer:
                    mesaj += "soruyu boş bırakama";
                    break;
                case MembershipCreateStatus.InvalidEmail:
                    mesaj += "email alanını boş bırakama";
                    break;
                case MembershipCreateStatus.DuplicateUserName:
                    mesaj += "bu kullanıcı var ";
                    break;
                case MembershipCreateStatus.DuplicateEmail:
                    mesaj += "bu e-mail var ";
                    break;
                case MembershipCreateStatus.UserRejected:
                    break;
                case MembershipCreateStatus.InvalidProviderUserKey:
                    break;
                case MembershipCreateStatus.DuplicateProviderUserKey:
                    break;
                case MembershipCreateStatus.ProviderError:
                    break;
                default:
                    break;
            }
            ViewBag.mesaj = mesaj;

            if (durum == MembershipCreateStatus.Success)
            {
                return RedirectToAction("Index");

            }
            else
            {
                return View();

            }







        }
    }
}