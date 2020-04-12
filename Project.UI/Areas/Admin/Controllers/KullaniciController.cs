using Project.Model.Entities;
using Project.Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Project.UI.Areas.Admin.Controllers
{
    public class KullaniciController : Controller
    {
        // GET: Admin/Kullanici

        AppUserService kullaniciService = new AppUserService();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Signin(string username,string password)
        {
            AppUser kullanici = kullaniciService.GetByDefault(x => (x.UserName == username || x.Email == username) && x.Password == password);
            bool islem = false;

            if (kullanici != null)
            {
                FormsAuthentication.SetAuthCookie(kullanici.UserName, true);
                islem = true;
            }

            return Json(new { islemSonuc = islem,username=kullanici.UserName},JsonRequestBehavior.AllowGet);
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}