using CarProject.Data;
using CarProject.Data.Model;
using CarProject.Data;
using CarProject.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CarProject.Business
{
    /// <summary>
    /// Създава се бизнес слой, който работи с БД.
    /// </summary>
    /// <remarks>
    /// <c>CarHouseBusiness</c> дава възможност за добавяне, изтриване, актуализиране и извличане на информация, 
    /// която се запазва в БД
    /// </remarks>
    class CarHouseBusiness
    {
        /// <value>
        /// <c>carhouseContext</c> е нов обект за използване на връзката с БД от клас <c>CarHouseContext</c> 
        /// </value>
        /// <remarks>
        /// В текущия клас вече може да се работи с данните от клас <c>CarHouseContext</c>.
        /// </remarks>
        private CarHouseContext carhouseContext;

        //Add
        /// <summary>
        ///Метод за добавяне на модел към базата данни
        /// </summary>
        /// /// <remarks>
        /// Използва се връзката с <c>Modelss</c> от клас <c>CarHouseContext</c>, за да се добавият нови данни към нея.
        /// Направените промени се запазват.
        /// </remarks>
        public void AddModel(Modell modell)
        {
            using (carhouseContext = new CarHouseContext())
            {
                carhouseContext.Modells.Add(modell);
                carhouseContext.SaveChanges();
            }
        }
        /// <summary>
        ///Метод за добавяне на марка към базата данни
        /// </summary>
        /// /// <remarks>
        /// Използва се връзката с <c>Brands</c> от клас <c>CarHouseContext</c>, за да се добавият нови данни към нея.
        /// Направените промени се запазват.
        /// </remarks>
        public void AddBrand(Brand brand)
        {
            using (carhouseContext = new CarHouseContext())
            {
                carhouseContext.Brands.Add(brand);
                carhouseContext.SaveChanges();
            }
        }
        /// <summary>
        ///Метод за добавяне на кола към базата данни
        /// </summary>
        /// /// <remarks>
        /// Използва се връзката с <c>Cars</c> от клас <c>CarHouseContext</c>, за да се добавият нови данни към нея.
        /// Направените промени се запазват.
        /// </remarks>
        public void AddCar(Car car)
        {
            using (carhouseContext = new CarHouseContext())
            {
                carhouseContext.Cars.Add(car);
                carhouseContext.SaveChanges();
            }
        }
        /// <summary>
        ///Метод за добавяне на клиент към базата данни
        /// </summary>
        /// /// <remarks>
        /// Използва се връзката с <c>Clients</c> от клас <c>CarHouseContext</c>, за да се добавият нови данни към нея.
        /// Направените промени се запазват.
        /// </remarks>
        public void AddClient(Client client)
        {
            using (carhouseContext = new CarHouseContext())
            {
                carhouseContext.Clients.Add(client);
                carhouseContext.SaveChanges();
            }
        }
        /// <summary>
        ///Метод за добавяне на поръчка към базата данни
        /// </summary>
        /// /// <remarks>
        /// Използва се връзката с <c>Orders</c> от клас <c>CarHouseContext</c>, за да се добавият нови данни към нея.
        /// Направените промени се запазват.
        /// </remarks>
        public void AddOrder(Order order)
        {
            using (carhouseContext = new CarHouseContext())
            {
                carhouseContext.Orders.Add(order);
                carhouseContext.SaveChanges();
            }
        }

        //Update
        /// <summary>
        ///Метод за aктуализиранe на модел от базата данни
        /// </summary>
        /// /// <remarks>
        /// Използва се връзката с <c>Modells</c> от клас <c>CarHouseContext</c>, за да се актуализират данните в нея.
        /// Направените промени се запазват.
        /// </remarks>
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
        /// <summary>
        ///Метод за aктуализиранe на марка от базата данни
        /// </summary>
        /// /// <remarks>
        /// Използва се връзката с <c>Brands</c> от клас <c>CarHouseContext</c>, за да се актуализират данните в нея.
        /// Направените промени се запазват.
        /// </remarks>
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
        /// <summary>
        ///Метод за aктуализиранe на кола от базата данни
        /// </summary>
        /// /// <remarks>
        /// Използва се връзката с <c>Cars</c> от клас <c>CarHouseContext</c>, за да се актуализират данните в нея.
        /// Направените промени се запазват.
        /// </remarks>
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
        /// <summary>
        ///Метод за aктуализиранe на клиент от базата данни
        /// </summary>
        /// /// <remarks>
        /// Използва се връзката с <c>Clients</c> от клас <c>CarHouseContext</c>, за да се актуализират данните в нея.
        /// Направените промени се запазват.
        /// </remarks>
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
        /// <summary>
        ///Метод за aктуализиранe на поръчка от базата данни
        /// </summary>
        /// /// <remarks>
        /// Използва се връзката с <c>Orders</c> от клас <c>CarHouseContext</c>, за да се актуализират данните в нея.
        /// Направените промени се запазват.
        /// </remarks>
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
        /// <summary>
        ///Метод за изтриване на модел от базата данни
        /// </summary>
        /// /// <remarks>
        /// Използва се връзката с <c>Modells</c> от клас <c>CarHouseContext</c>, за да се изтрият данните в нея.
        /// Направените промени се запазват.
        /// </remarks>
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
        /// <summary>
        ///Метод за изтриване на марка от базата данни
        /// </summary>
        /// /// <remarks>
        /// Използва се връзката с <c>Brands</c> от клас <c>CarHouseContext</c>, за да се изтрият данните в нея.
        /// Направените промени се запазват.
        /// </remarks>
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
        /// <summary>
        ///Метод за изтриване на кола от базата данни
        /// </summary>
        /// /// <remarks>
        /// Използва се връзката с <c>Cars</c> от клас <c>CarHouseContext</c>, за да се изтрият данните в нея.
        /// Направените промени се запазват.
        /// </remarks>
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
        /// <summary>
        ///Метод за изтриване на клиент от базата данни
        /// </summary>
        /// /// <remarks>
        /// Използва се връзката с <c>Clients</c> от клас <c>CarHouseContext</c>, за да се изтрият данните в нея.
        /// Направените промени се запазват.
        /// </remarks>
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
        /// <summary>
        ///Метод за изтриване на поръчка от базата данни
        /// </summary>
        /// /// <remarks>
        /// Използва се връзката с <c>Orders</c> от клас <c>CarHouseContext</c>, за да се изтрият данните в нея.
        /// Направените промени се запазват.
        /// </remarks>
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
        /// <summary>
        /// Метод за вземане на модел от базата данни по Id
        /// </summary>
        /// /// <remarks>
        /// Използва се връзката с <c>Modells</c> от клас <c>CarHouseContext</c>, за да открие зададено Id.
        /// </remarks>
        public Modell GetModel(int id)
        {
            using (carhouseContext = new CarHouseContext())
            {
                return carhouseContext.Modells.Find(id);
            }
        }
        /// <summary>
        /// Метод за вземане на марка от базата данни по Id
        /// </summary>
        /// /// <remarks>
        /// Използва се връзката с <c>Brands</c> от клас <c>CarHouseContext</c>, за да открие зададено Id.
        /// </remarks>
        public Brand GetBrand(int id)
        {
            using (carhouseContext = new CarHouseContext())
            {
                return carhouseContext.Brands.Find(id);
            }
        }
        /// <summary>
        /// Метод за вземане на кола от базата данни по Id
        /// </summary>
        /// /// <remarks>
        /// Използва се връзката с <c>Cars</c> от клас <c>CarHouseContext</c>, за да открие зададено Id.
        /// Направените промени се запазват.
        /// </remarks>
        public Car GetCar(int id)
        {
            using (carhouseContext = new CarHouseContext())
            {
                return carhouseContext.Cars.Find(id);
            }
        }
        /// <summary>
        /// Метод за вземане на клиент от базата данни по Id
        /// </summary>
        /// /// <remarks>
        /// Използва се връзката с <c>Clients</c> от клас <c>CarHouseContext</c>, за да открие зададено Id.
        /// </remarks>
        public Client GetClient(int id)
        {
            using (carhouseContext = new CarHouseContext())
            {
                return carhouseContext.Clients.Find(id);
            }
        }
        /// <summary>
        /// Метод за вземане на поръчка от базата данни по Id
        /// </summary>
        /// /// <remarks>
        /// Използва се връзката с <c>Orders</c> от клас <c>CarHouseContext</c>, за да открие зададено Id.
        /// Направените промени се запазват.
        /// </remarks>
        public Order GetOrder(int id)
        {
            using (carhouseContext = new CarHouseContext())
            {
                return carhouseContext.Orders.Find(id);
            }
        }

        //ListAll
        /// <summary>
        /// Списък за вземaне на всички модели от базата данни
        /// </summary>
        /// <remarks>
        /// Връща крайния списък с моделите след направените промени.
        /// </remarks>
        public List<Modell> GetAllModels()
        {
            using (carhouseContext = new CarHouseContext())
            {
                return carhouseContext.Modells.ToList();
            }
        }
        /// <summary>
        /// Списък за вземaне на всички марки от базата данни
        /// </summary>
        /// <remarks>
        /// Връща крайния списък с марките след направените промени.
        /// </remarks>
        public List<Brand> GetAllBrands()
        {
            using (carhouseContext = new CarHouseContext())
            {
                return carhouseContext.Brands.ToList();
            }
        }

        /// <summary>
        /// Списък за вземaне на всички коли от базата данни
        /// </summary>
        /// <remarks>
        /// Връща крайния списък с колите след направените промени.
        /// </remarks>
        public List<Car> GetAllCars()
        {
            using (carhouseContext = new CarHouseContext())
            {
                return carhouseContext.Cars.ToList();
            }
        }
        /// <summary>
        /// Списък за вземaне на всички клиенти от базата данни
        /// </summary>
        /// <remarks>
        /// Връща крайния списък с клиентите след направените промени.
        /// </remarks>
        public List<Client> GetAllClients()
        {
            using (carhouseContext = new CarHouseContext())
            {
                return carhouseContext.Clients.ToList();
            }
        }
        /// <summary>
        /// Списък за вземaне на всички поръчки от базата данни
        /// </summary>
        /// <remarks>
        /// Връща крайния списък с поръчките след направените промени.
        /// </remarks>
        public List<Order> GetAllOrders()
        {
            using (carhouseContext = new CarHouseContext())
            {
                return carhouseContext.Orders.ToList();
            }
        }
    }
}

