using Project.Model.Entities;
using Project.Service.Option;
using Project.UI.Utility;
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
            return View(kullaniciService.GetAll());
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


        public ActionResult Sil(int id) 
        {
            kullaniciService.Remove(id);
            return RedirectToAction("Index", "Kullanici");
        }

        public ActionResult Duzenle(int id)
        {
            AppUser secilenKisi = kullaniciService.GetByID(id);
            if(secilenKisi!=null)
            {
                return View(secilenKisi);
            }
            return RedirectToAction("Index", "Kullanici");
        }

        [HttpPost]
        public ActionResult Duzenle(AppUser kullanici,HttpPostedFileBase Image)
        {
            

            AppUser secilenKisi = kullaniciService.GetByID(kullanici.ID);
            if (secilenKisi != null)
            {
                if (Image != null)
                {
                    secilenKisi.ImagePath = ImageUploader.UploadImage("/UserPictures/", Image);
                }

                if(secilenKisi.ImagePath=="1" || secilenKisi.ImagePath == "0")
                {
                    secilenKisi.ImagePath = "/UserPicutres/user.png";
                }

                secilenKisi.Name = kullanici.Name;
                secilenKisi.LastName = kullanici.LastName;
                secilenKisi.UserName = kullanici.UserName;
                secilenKisi.IsActive = kullanici.IsActive;
                secilenKisi.Rol = kullanici.Rol;
                kullaniciService.Save();
            }
            return RedirectToAction("Index", "Kullanici");

        }
    }
}