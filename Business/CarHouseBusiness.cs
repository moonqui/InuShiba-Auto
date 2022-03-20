using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Model;

namespace Business
{
    public class CarHouseBusiness
    {
        private CarHouseContext carhouseContext;

        //Add
        /// <summary>
        /// Добавя нов запис в таблица <c>Modell</c> в базата данни.
        /// </summary>
        public void AddModel(Modell modell)
        {
            using (carhouseContext = new CarHouseContext())
            {
                carhouseContext.Modells.Add(modell);
                carhouseContext.SaveChanges();
            }
        }
        public void AddBrand(Brand brand)
        {
            using (carhouseContext = new CarHouseContext())
            {
                carhouseContext.Brands.Add(brand);
                carhouseContext.SaveChanges();
            }
        }
        public void AddCar(Car car)
        {
            using (carhouseContext = new CarHouseContext())
            {
                carhouseContext.Cars.Add(car);
                carhouseContext.SaveChanges();
            }
        }
        public void AddClient(Client client)
        {
            using (carhouseContext = new CarHouseContext())
            {
                carhouseContext.Clients.Add(client);
                carhouseContext.SaveChanges();
            }
        }
        public void AddOrder(Order order)
        {
            using (carhouseContext = new CarHouseContext())
            {
                carhouseContext.Orders.Add(order);
                carhouseContext.SaveChanges();
            }
        }

        //Update
        public void UpdateModel(Modell modell)
        {
            using (carhouseContext = new CarHouseContext())
            {
                var item = carhouseContext.Modells.Find(modell.ModellId);
                if (item != null)
                {
                    carhouseContext.Entry(item).CurrentValues.SetValues(modell);
                    carhouseContext.SaveChanges();
                }
            }
        }
        public void UpdateBrand(Brand brand)
        {
            using (carhouseContext = new CarHouseContext())
            {
                var item = carhouseContext.Brands.Find(brand.BrandId);
                if (item != null)
                {
                    carhouseContext.Entry(item).CurrentValues.SetValues(brand);
                    carhouseContext.SaveChanges();
                }
            }
        }
        public void UpdateCar(Car car)
        {
            using (carhouseContext = new CarHouseContext())
            {
                var item = carhouseContext.Cars.Find(car.CarId);
                if (item != null)
                {
                    carhouseContext.Entry(item).CurrentValues.SetValues(car);
                    carhouseContext.SaveChanges();
                }
            }
        }
        public void UpdateClient(Client client)
        {
            using (carhouseContext = new CarHouseContext())
            {
                var item = carhouseContext.Clients.Find(client.ClientId);
                if (item != null)
                {
                    carhouseContext.Entry(item).CurrentValues.SetValues(client);
                    carhouseContext.SaveChanges();
                }
            }
        }
        public void UpdateOrder(Order order)
        {
            using (carhouseContext = new CarHouseContext())
            {
                var item = carhouseContext.Orders.Find(order.OrderId);
                if (item != null)
                {
                    carhouseContext.Entry(item).CurrentValues.SetValues(order);
                    carhouseContext.SaveChanges();
                }
            }
        }

        //Delete
        public void DeleteModel(int id)
        {
            using (carhouseContext = new CarHouseContext())
            {
                var model = carhouseContext.Modells.Find(id);
                if (model != null)
                {
                    carhouseContext.Modells.Remove(model);
                    carhouseContext.SaveChanges();
                }
            }
        }
        public void DeleteBrand(int id)
        {
            using (carhouseContext = new CarHouseContext())
            {
                var brand = carhouseContext.Brands.Find(id);
                if (brand != null)
                {
                    carhouseContext.Brands.Remove(brand);
                    carhouseContext.SaveChanges();
                }
            }
        }
        public void DeleteCar(int id)
        {
            using (carhouseContext = new CarHouseContext())
            {
                var car = carhouseContext.Cars.Find(id);
                if (car != null)
                {
                    carhouseContext.Cars.Remove(car);
                    carhouseContext.SaveChanges();
                }
            }
        }
        public void DeleteClient(int id)
        {
            using (carhouseContext = new CarHouseContext())
            {
                var car = carhouseContext.Clients.Find(id);
                if (car != null)
                {
                    carhouseContext.Clients.Remove(car);
                    carhouseContext.SaveChanges();
                }
            }
        }
        public void DeleteOrder(int id)
        {
            using (carhouseContext = new CarHouseContext())
            {
                var car = carhouseContext.Orders.Find(id);
                if (car != null)
                {
                    carhouseContext.Orders.Remove(car);
                    carhouseContext.SaveChanges();
                }
            }
        }

        //Update & Fetch
        public Modell GetModel(int id)
        {
            using (carhouseContext = new CarHouseContext())
            {
                return carhouseContext.Modells.Find(id);
            }
        }
        public Brand GetBrand(int id)
        {
            using (carhouseContext = new CarHouseContext())
            {
                return carhouseContext.Brands.Find(id);
            }
        }
        public Car GetCar(int id)
        {
            using (carhouseContext = new CarHouseContext())
            {
                return carhouseContext.Cars.Find(id);
            }
        }
        public Client GetClient(int id)
        {
            using (carhouseContext = new CarHouseContext())
            {
                return carhouseContext.Clients.Find(id);
            }
        }
        public Order GetOrder(int id)
        {
            using (carhouseContext = new CarHouseContext())
            {
                return carhouseContext.Orders.Find(id);
            }
        }

        //ListAll
        public List<Modell> GetAllModels()
        {
            using (carhouseContext = new CarHouseContext())
            {
                return carhouseContext.Modells.ToList();
            }
        }
        public List<Brand> GetAllBrands()
        {
            using (carhouseContext = new CarHouseContext())
            {
                return carhouseContext.Brands.ToList();
            }
        }
        public List<Car> GetAllCars()
        {
            using (carhouseContext = new CarHouseContext())
            {
                return carhouseContext.Cars.ToList();
            }
        }
        public List<Client> GetAllClients()
        {
            using (carhouseContext = new CarHouseContext())
            {
                return carhouseContext.Clients.ToList();
            }
        }
        public List<Order> GetAllOrders()
        {
            using (carhouseContext = new CarHouseContext())
            {
                return carhouseContext.Orders.ToList();
            }
        }
    }
}

