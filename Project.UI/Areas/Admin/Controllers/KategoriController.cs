using Project.Model.Entities;
using Project.Service.Option;
using Project.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.UI.Areas.Admin.Controllers
{
    [Authorize]
    public class KategoriController : BaseController
    {
        
        CategoryService katService = new CategoryService();

        public ActionResult Index()
        {
            List<Category> kategorilerim = katService.GetAll();

            return View(kategorilerim);
        }


        // [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Category yeniKategori)
        {

          int sonuc = katService.Add(yeniKategori);
           
            if (sonuc > 0)
            {
                // ekleme işlemi başarılıdır.
                ShowMessage(MessageType.Success, "Ekleme işlemi başarılıdır.", 3, true);
                return RedirectToAction("Index","Kategori");

            }
            else
            {
                ShowMessage(MessageType.Error, "Ekleme işlemi başarısız oldu kontrol ediniz.", 3, false);
                return View();
            }
            
        }

        public ActionResult Duzenle(int id)
        {
            Category bulunanKat = katService.GetByID(id);

            if (bulunanKat != null)
            {
                return View(bulunanKat);
            }

            return RedirectToAction("Index", "Kategori");
        }

        [HttpPost]
        public ActionResult Duzenle(Category duzenlenenKat)
        {
            Category bulunanKat = katService.GetByID(duzenlenenKat.ID);

            if (bulunanKat != null)
            {
                bulunanKat.Name = duzenlenenKat.Name;
                bulunanKat.Description = duzenlenenKat.Description;
                bulunanKat.IsActive = duzenlenenKat.IsActive;
                katService.Update(bulunanKat);

                ShowMessage(MessageType.Success, "Düzenleme işlemi başarılı", 3, true);


                return View(bulunanKat);
            }
            ShowMessage(MessageType.Warning, "Seçilen kategori bulunamadı", 5, false);
            return RedirectToAction("Index", "Kategori");
        }

        public ActionResult Sil(int id)
        {
            //Category bulunanKat = katService.GetByID(id);
            //if (bulunanKat != null)
            //{
            //    katService.Remove(bulunanKat);
            //}


            katService.Remove(id);
            return RedirectToAction("Index", "Kategori");
        }
    }
}