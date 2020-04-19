using Project.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model.Entities
{
    public class Order : CoreEntity
    {
        public Order()
        {
            OrderDetails = new List<OrderDetail>();
        }
        public bool Confirmed { get; set; }

        public int AppUserID { get; set; }

        public virtual AppUser AppUser { get; set; }

        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}
