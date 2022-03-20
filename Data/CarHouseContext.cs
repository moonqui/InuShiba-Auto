using CarProject.Data.Model;
using CarProject.Business;
using Microsoft.EntityFrameworkCore;


namespace CarProject.Data
{
    public class CarHouseContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Modell> Modells { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Client> Clients { get; set; }
        public CarHouseContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=CarHouse1;user=root;password=ssgsql9050");
        }
    }
}
