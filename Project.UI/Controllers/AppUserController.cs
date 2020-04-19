using Project.Model.Entities;
using Project.Service.Option;
using Project.UI.Models;
using Project.UI.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Project.UI.Controllers
{
    public class AppUserController : Controller
    {
        // GET: AppUser
        AppUserService kullaniciService = new AppUserService();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel kullanici)
        {
            if (ModelState.IsValid)
            {
                AppUser girisyapan = kullaniciService.GetByDefault(x => (x.UserName == kullanici.UserName || x.Email == kullanici.UserName) && x.Password == kullanici.Password);
                if (girisyapan != null)
                {

                    FormsAuthentication.SetAuthCookie(girisyapan.UserName, kullanici.RememberMe);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }


        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(AppUserViewModel kullanici, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                AppUser yeniKullanici = new AppUser();
                yeniKullanici.Email = kullanici.Email;
                yeniKullanici.Name = kullanici.Name;
                yeniKullanici.LastName = kullanici.LastName;
                yeniKullanici.Password = kullanici.Password;
                yeniKullanici.UserName = kullanici.UserName;


                yeniKullanici.ImagePath = ImageUploader.UploadImage("/UserPictures/", Image);

                if (yeniKullanici.ImagePath == "0" || yeniKullanici.ImagePath == "1")
                {
                    yeniKullanici.ImagePath = "/UserPictures/user.png";
                }


                kullaniciService.Add(yeniKullanici);
                return View("Login");
                // kayıt işlemi yapılabilir.
            }
            return View();
        }


        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Home");
        }
    }
}