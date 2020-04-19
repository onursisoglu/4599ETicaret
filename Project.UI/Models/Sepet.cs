using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.UI.Models
{
    public class Sepet
    {
        public int ID { get; set; }
        public string UrunAdi { get; set; }
        public decimal Fiyati { get; set; }
        public short Adet { get; set; }
        public string ImagePath { get; set; }
    }
}