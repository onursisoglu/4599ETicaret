﻿using Project.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model.Entities
{
  public  class OrderDetail : CoreEntity
    {
        public decimal? UnitPrice { get; set; }
        public short Quantity { get; set; }

        public int ProductID { get; set; }

        public int OrderID { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
