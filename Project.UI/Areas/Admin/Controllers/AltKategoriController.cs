using Project.Model.Entities;
using Project.Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.UI.Models;

namespace Project.UI.Areas.Admin.Controllers
{
    [Authorize]
    public class AltKategoriController : BaseController
    {
        // GET: Admin/AltKategori
        CategoryService katService = new CategoryService();
        SubCategoryService altKatService = new SubCategoryService();

        public ActionResult Index() // Listeleme yapmak için kullanılır.
        {
            return View(altKatService.GetAll());
        }

        public ActionResult Ekle() // sayfayı göstermek için
        {
            List<Category> anaKategoriler = katService.GetAll();
            return View(anaKategoriler);
        }

        [HttpPost]
        public ActionResult Ekle(SubCategory veri) // gönderilen sayfadan verileri yakalamak için.
        {

          int sonuc = altKatService.Add(veri);

            if (sonuc > 0)
            {
                ShowMessage(MessageType.Success, "Ekleme işlemi başarılı", 3, false);
            }
            else
            {
                ShowMessage(UI.Models.MessageType.Error, "İşlem başarısız", 5, false);
            }

            return RedirectToAction("Index","AltKategori");
        }

        public ActionResult Duzenle(int id)
        {
            SubCategory altKategori = altKatService.GetByID(id);

            if(altKategori!=null)
            {
                // anakategorilerinde listelenmesi yapılmalı.,

                ViewBag.AnaKategoriler = katService.GetAll();

                return View(altKategori);
            }

            ShowMessage(MessageType.Warning, "Seçilen veri bulunamadı.", 3, true);

            return RedirectToAction("Index","AltKategori");
        }

        [HttpPost]
        public ActionResult Duzenle(SubCategory veri)
        {
            SubCategory altKategori = altKatService.GetByID(veri.ID);
            altKategori.Description = veri.Description;
            altKategori.Name = veri.Name;
            altKategori.CategoryID = veri.CategoryID;
            altKatService.Save();

            ShowMessage(MessageType.Success, "Güncelleme başarılı", 3, true);

            return RedirectToAction("Index", "AltKategori");

            
        }

        public ActionResult Sil(int id)
        {
           bool sonuc =  altKatService.Remove(id);

            if (sonuc)
            {
                ShowMessage(MessageType.Success, "Silme işlemi başarılıdır", 3, true);
            }
            else
            {
                ShowMessage(MessageType.Warning, "İşlem başarısızdır.", 3, true);
            }

            return RedirectToAction("Index", "AltKategori");
        }
    }
}