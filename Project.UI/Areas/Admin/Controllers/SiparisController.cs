using Project.Model.Entities;
using Project.Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.UI.Areas.Admin.Controllers
{
    public class SiparisController : Controller
    {
        // GET: Admin/Siparis
        OrderService siparisService = new OrderService();
        OrderDetailService siparisDetayService = new OrderDetailService();
        public ActionResult Index()
        {
            return View();
        }

       public ActionResult PendingOrderList()
        {
            return View(siparisService.GetDefault(x => x.Confirmed == false && x.IsActive).OrderByDescending(x => x.CreatedDate).ToList());
        }


        public ActionResult Details(int id)
        {
            List<OrderDetail> model = siparisDetayService.GetDefault(x => x.OrderID == id);
            return View(model);
        }


       public ActionResult ConfirmOrder(int id)
        {
            Order siparis = siparisService.GetByID(id);

            siparis.Confirmed = true;
            siparisService.Save();
            
            return RedirectToAction("PendingOrderList", "Siparis");
        }


        public ActionResult RejectOrder(int id)
        {

            Order siparis = siparisService.GetByID(id);

            siparis.IsActive = false;
            siparisService.Save();
            return RedirectToAction("PendingOrderList", "Siparis");
        }
    }
}