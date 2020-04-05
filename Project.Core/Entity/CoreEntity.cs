using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Entity
{
   public class CoreEntity
    {
        // Bu class tüm tablolard (classlarda) ortak kullanılacak özellikleri barındıran yerdir.


        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedComputerName { get; set; }
        public string CreatedUserName { get; set; }

        public DateTime? ModifiedDate { get; set; }
        public string ModifiedComputerName { get; set; }
        public string ModifiedUserName { get; set; }

        public bool IsActive { get; set; } 





    }
}
