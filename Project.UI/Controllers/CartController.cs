using Project.Model.Entities;
using Project.Service.Option;
using Project.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.UI.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        ProductService urunService = new ProductService();
        public ActionResult Index()
        {
            List<Sepet> kullaniciSepeti = new List<Sepet>();
            if (Session["sepetListesi"] != null)
            {
                kullaniciSepeti = Session["sepetListesi"] as List<Sepet>;
            }
       
            return View(kullaniciSepeti);
        }

        // Sepete Ekleme işlemi.
        public ActionResult AddToCart(int id)
        {
            Product p = urunService.GetByID(id);
            List<Sepet> kullaniciSepeti = new List<Sepet>();

            if (Session["sepetListesi"] != null)
            {
                kullaniciSepeti = Session["sepetListesi"] as List<Sepet>;
            }
            Sepet eklenecekUrun;

            if (kullaniciSepeti.Any(x => x.ID == id)) // sepette parametre ile eşleşen id ' de ürün var mı yok mu ? 
            {
                // var ise ürünü bul
                eklenecekUrun = kullaniciSepeti.FirstOrDefault(x => x.ID == id);
                // adeti bir arttır.

                eklenecekUrun.Adet++;
            }
            //sepette parametre ile eşleşen id' de ürün yoksa eğer gel yeni ürün oluşturup sepete ekle.
            else
            {
               eklenecekUrun = new Sepet();
                eklenecekUrun.ID = p.ID;
                eklenecekUrun.Fiyati = p.UnitPrice;
                eklenecekUrun.ImagePath = p.ImagePath;
                eklenecekUrun.UrunAdi = p.Name;
                eklenecekUrun.Adet = 1;

                kullaniciSepeti.Add(eklenecekUrun);
            }

            Session["sepetListesi"] = kullaniciSepeti;

            return Json(kullaniciSepeti, JsonRequestBehavior.AllowGet);
        }
    }
}