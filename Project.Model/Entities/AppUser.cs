﻿using Project.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model.Entities
{
    public enum Role
    {
        Member=1,
        Admin=2
    }
   public class AppUser:CoreEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string ImagePath { get; set; }
        public DateTime? BirthDate { get; set; }
        public Role Rol { get; set; }

        public virtual List<Order> Orders { get; set; }
    }
}
