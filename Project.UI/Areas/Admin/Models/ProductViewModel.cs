using Project.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.UI.Areas.Admin.Models
{
    public class ProductViewModel
    {
        public Product  UrunBilgisi{ get; set; }

        public List<SubCategory> AltKategoriler { get; set; }
    }
}