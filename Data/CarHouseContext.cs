using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Data.Model;

namespace Data
{
    public class CarHouseContext : DbContext
    {
        public CarHouseContext()
            : base("name=CarHouseContext")
        {

        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Modell> Modells { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
