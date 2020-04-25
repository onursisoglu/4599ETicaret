using Project.Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.UI.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        OrderService siparisService = new OrderService();
        public ActionResult Index()
        {
            int count = siparisService.GetDefault(x => x.Confirmed == false && x.IsActive).Count;
            ViewBag.SipariSayisi = count;
            return View();
        }


        public ActionResult NoAuthorize(string ReturnUrl)
        {
            if(ReturnUrl!=null)
            {
                ViewBag.ReturnUrl = ReturnUrl;
            }
            
            return View();
        }
    }
}