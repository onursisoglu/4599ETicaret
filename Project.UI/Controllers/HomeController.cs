using Project.Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        ProductService urunService = new ProductService();
        public ActionResult Index()
        {
            return View(urunService.GetActive());
        }
    }
}