using Project.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model.Entities
{
   public class Product:CoreEntity
    {
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public string ImagePath { get; set; }

        public int SubCategoryID { get; set; }

        public virtual SubCategory SubCategory { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}
