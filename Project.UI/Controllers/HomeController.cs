using Project.Model.Entities;
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

        public ActionResult _CategoryList()
        {
            CategoryService katService = new CategoryService();

           List<Category> kategoriListem =  katService.GetActive();

            return PartialView(kategoriListem);
        }


        public ActionResult HomePageSlider()
        {
            List<Product> son5urun = urunService.GetDefault(x => x.IsActive).OrderByDescending(x => x.CreatedDate).Take(5).ToList();
            return PartialView(son5urun);
        }
    }
}