using Project.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model.Entities
{
    public class SubCategory : CoreEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int CategoryID { get; set; }
        public virtual Category MainCategory { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
