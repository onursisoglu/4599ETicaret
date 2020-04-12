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
        public ActionResult Index()
        {
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