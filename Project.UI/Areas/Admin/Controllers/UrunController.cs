using Project.Model.Entities;
using Project.Service.Option;
using Project.UI.Areas.Admin.Models;
using Project.UI.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.UI.Models;

namespace Project.UI.Areas.Admin.Controllers
{
    public class UrunController : BaseController
    {
        // GET: Admin/Urun

        SubCategoryService altKatService = new SubCategoryService();
        ProductService urunService = new ProductService();

        public ActionResult Index()
        {

            return View(urunService.GetAll());
        }


        public ActionResult Ekle()
        {

            return View(altKatService.GetAll());
        }


        [HttpPost]
        public ActionResult Ekle(Product urun, HttpPostedFileBase Image)
        {
            try
            {
                urun.ImagePath = ImageUploader.UploadImage("/ProductPictures/", Image);
                if (urun.ImagePath == "1" || urun.ImagePath == "0")
                {
                    urun.ImagePath = "/ProductPictures/07011652-857b4d.jpg";
                }
                urunService.Add(urun);
                ShowMessage(MessageType.Success, "ekleme işlemi başarılıdır.", 3, true);


            }
            catch (Exception)
            {

                ShowMessage(MessageType.Error, "hata oluştu", 3, false);
            }



            return RedirectToAction("Index", "Urun");
        }

        public ActionResult Duzenle(int id)
        {

            Product secilenUrun = urunService.GetByID(id);

            if (secilenUrun != null)
            {
                ProductViewModel vm = new ProductViewModel();

                vm.UrunBilgisi = secilenUrun;
                vm.AltKategoriler = altKatService.GetAll();

                return View(vm);
            }
            return RedirectToAction("Index", "Urun");


        }

        [HttpPost]
        public ActionResult Duzenle(Product veri, HttpPostedFileBase Image)
        {
            Product secilenUrun = urunService.GetByID(veri.ID);

            if (secilenUrun != null)
            {
                secilenUrun.ImagePath = ImageUploader.UploadImage("/ProductPictures/", Image);
                if(secilenUrun.ImagePath=="1" || secilenUrun.ImagePath=="0")
                {
                    secilenUrun.ImagePath = "/ProductPictures/07011652-857b4d.jpg";
                }
                secilenUrun.Name = veri.Name;
                secilenUrun.UnitsInStock = veri.UnitsInStock;
                secilenUrun.UnitPrice = veri.UnitPrice;
                secilenUrun.SubCategoryID = veri.SubCategoryID;
                secilenUrun.IsActive = veri.IsActive;
                urunService.Save();
            }

            return RedirectToAction("Index", "Urun");
        }

        public ActionResult Sil(int id)
        {
            urunService.Remove(id);
            return RedirectToAction("Index", "Urun");
        }
    }
}