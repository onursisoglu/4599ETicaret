using Project.Model.Entities;
using Project.Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.UI.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        ProductService urunService = new ProductService();
        public ActionResult Index()
        {
            return View();
        }

        // seçilen alt kategoriye ait ürünlerin döndürüldüğü yer.
        public ActionResult GetByCategory(int id)
        {
            List<Product> kategorininUrunleri = urunService.GetDefault(x => x.IsActive && x.SubCategoryID == id);

            return View(kategorininUrunleri);
        }

        //Ürün ıd sine göre ürün detay sayfasına git.
        public ActionResult GetByProduct(int id)
        {
            Product urun = urunService.GetByID(id);

            if (urun != null)
            {
                ViewBag.BenzerUrunler = urunService.GetDefault(x => x.IsActive && x.ID!=urun.ID && x.SubCategoryID == urun.SubCategoryID).OrderByDescending(x=>x.CreatedDate).Take(4).ToList();
                
                return View(urun);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}