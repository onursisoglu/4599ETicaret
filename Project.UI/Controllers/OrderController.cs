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
    public class OrderController : Controller
    {
        // GET: Order
        AppUserService kullaniciservice = new AppUserService();
        OrderService siparisService = new OrderService();
        OrderDetailService siparisDetaService = new OrderDetailService();
        ProductService urunService = new ProductService();
        public ActionResult Add()
        {
            if (Session["sepetListesi"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            List<Sepet> kullaniciSepeti = Session["sepetListesi"] as List<Sepet>;

                Order siparis = new Order();
                AppUser kullanici = kullaniciservice.GetByDefault(x => x.UserName == HttpContext.User.Identity.Name);

                siparis.AppUserID = kullanici.ID;
            siparisService.Add(siparis);

            Product p = new Product();


                foreach (var item in kullaniciSepeti)
                {
                    p = urunService.GetByID(item.ID);

                   OrderDetail od = new OrderDetail()
                    {
                        ProductID = p.ID,
                        Quantity = item.Adet,
                        UnitPrice = item.Fiyati,
                        OrderID = siparis.ID
                    };
                siparisDetaService.Add(od);
                }

                
                Guid siparisKodu = Guid.NewGuid();

                

           
            string metin = "Siparişiniz başarıyla oluşturuldu. Sipariş Kodunuz " + siparisKodu + "\n En geç " + siparis.CreatedDate.AddDays(2) + " iş günü içerisinde kargoya verilecektir.";
            return View("OrderInformation",model:metin);
        }

        public ActionResult OrderInformation(string bilgilendirmeMetni)
        {
            return View(model:bilgilendirmeMetni);
        }
    }
}