using Project.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model.Context
{
    /* Bu class veri tabanı ile  iletişim kurduğumuz yerdir. Code firstte hangi classların veritabanında tablo olması gerektiğini belirtiriz. BU iletişimi sağlamak için Entity Framework kütüphanesi ile ilgili .net' in sunduğu DbContext class'ını miras almalıyız.*/
   public class ProjectContext:DbContext
    {
        public ProjectContext()
        {
            //Database.Connection.ConnectionString = "Server=.;Database=EcommerceDB;uid=sa;pwd=123";  sql server auth.
            Database.Connection.ConnectionString = "Server=.;Database=EcommerceDB;Trusted_Connection=true"; // windows auth.
        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

    }
}
