using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Car
    {
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public int ModellId { get; set; }
        public Brand Brands { get; set; }
        public Modell Modells { get; set; }
        public double Price { get; set; }
        public string Fuel { get; set; }
        public string Colour { get; set; }
        public Order Order { get; set; }
    }
}
