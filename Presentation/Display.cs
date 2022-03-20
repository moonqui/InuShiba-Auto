using CarProject.Business;
using CarProject.Data.Model;
using System;


namespace CarProject.Presentation
{
    /// <summary>
    /// Описване на потребителския интерфейс.
    /// </summary>
    /// <remarks>
    /// <c>Display</c> представя възможност за използване 
    /// на различни методи за работа с база данни като 
    /// добавяне, изтриване, актуализиране, извличане.
    /// </remarks>
    public class Display 
    {
        /// <value>
        /// <c>closeOpearatioId</c> приема стойността, която ще се използва за
        /// прекратяването на програмата.
        /// </value>
        private int closeOperationId = 6;

        /// <value>
        /// <c>carhouseBusiness</c> свързва <c>Display</c> с <c>CarHouseBusiness</c>.
        /// </value>
        /// <remarks>
        /// В текущия клас вече може да се работи с данните от клас <c>CarHouseBusiness</c>.
        /// </remarks>
        private CarHouseBusiness carhouseBusiness = new CarHouseBusiness();

        /// <summary>
        /// Насърчава програмата да използва метода за въвеждане 
        /// на информация от потребителя.
        /// </summary>
        public Display()
        {
            Input();
        }

        /// <summary>
        /// Mетод за визуално представяне на менюто върху потребителския интерфейс.
        /// </summary>
        /// <remarks>
        /// На интерфейса се извеждат всички възможни опции за въвеждане.
        /// </remarks>
        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40)); 
            Console.WriteLine(new string(' ', 18) + "MENU" + new string(' ', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Update");
            Console.WriteLine("3. Delete");
            Console.WriteLine("4. Fetch");
            Console.WriteLine("5. List All");
            Console.WriteLine("6. Exit");
            Console.WriteLine();
        }

        /// <summary>
        /// Дава се възможност на потребителя да избере да работи 
        /// с един от предложените методи, докато не прекрати програмата.
        /// </summary>
        /// <remarks>
        /// <list type="table">
        /// <item>
        /// <term>operation, do/while</term>
        /// <description>
        /// Потребителят въвежда стойност за <c>operation</c>, с която ще направи своя
        /// избор на метод за използване за работа с базата данни. Командата do/while
        /// ще се повтаря, докато потребителят не въведе 6, с което ще прекрати програмата.
        /// </description>
        /// </item>
        /// <item>
        /// <term>ShowMenu</term>
        /// <description>
        /// Използване на метода <c>ShowMenu</c>.
        /// </description>
        /// </item>
        /// <item>switch/case</item>
        /// <description>
        /// При въвеждане на 1 - се преминава към работа с метода <c>Add</c>,
        /// при въвеждане на 2 - се преминава към работа с метода <c>Update</c>,
        /// при въвеждане на 3 - се преминава към работа с метода <c>Delete</c>,
        /// при въвеждане на 4 - се преминава към работа с метода <c>Fetch</c>,
        /// при въвеждане на 5 - се преминава към работа с метода <c>ListAll</c>,
        /// при въвеждане на 6 - се прекратява програмата.
        /// </description>
        /// </list>
        /// </remarks>
        private void Input()
        {
            var operation = -1;
            do
            {
                ShowMenu();
                Console.Write("Your choice: ");
                operation = int.Parse(Console.ReadLine());
                Console.WriteLine();
                switch (operation)
                {
                    case 1:
                        Add();
                        break;
                    case 2:
                        Update();
                        break;
                    case 3:
                        Delete();
                        break;
                    case 4:
                        Fetch();
                        break;
                    case 5:
                        ListAll();
                        break;
                    default:
                        Console.WriteLine("Goodbye.");
                        break;
                }
            } while (operation != closeOperationId);
            Console.WriteLine();
        }

        /// <summary>
        /// Добавя нов запис в базата данни.
        /// </summary>
        /// <remarks>
        /// Новия запис се добавя в избраната чрез въвеждане върху потребителския интерфейс таблица.
        /// </remarks>
        /// <list type="table">
        /// <term>model</term>
        /// <description>
        /// Създава се нов запис в таблица <c>Modell</c> като се въведе името на модела.
        /// </description>
        /// <term>brand</term>
        /// <description>
        /// Създава се нов запис в таблица <c>Brand</c> като се въведе името на марката.
        /// </description>
        /// <term>car</term>
        /// <description>
        /// Създава се нов запис в таблица <c>Car</c> като се въведат изискваните данни за колата.
        /// </description>
        /// <term>client</term>
        /// <description>
        /// Създава се нов запис в таблица <c>Client</c> като се въведат изискваните данни за клиента.
        /// </description>
        /// <term>order</term>
        /// <description>
        /// Създава се нов запис в таблица <c>Order</c> като се въведат изискваните данни за поръчката.
        /// </description>
        /// </list>
        private void Add()
        {
            Console.WriteLine("Choose what to add:");
            Console.WriteLine("1. Model");
            Console.WriteLine("2. Brand");
            Console.WriteLine("3. Car");
            Console.WriteLine("4. Client");
            Console.WriteLine("5. Order");
            Console.WriteLine();
            Console.Write("Your choice (number): ");
            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine();
            switch (choice)
            {
                case 1:
                    Modell modell = new Modell();
                    Console.Write("Enter model name: ");
                    modell.ModellName = Console.ReadLine();
                    carhouseBusiness.AddModel(modell);
                    Console.WriteLine("Done.");
                    break;
                case 2:
                    Brand brand = new Brand();
                    Console.Write("Enter brand name: ");
                    brand.BrandName = Console.ReadLine();
                    carhouseBusiness.AddBrand(brand);
                    Console.WriteLine("Done.");
                    break;
                case 3:
                    Car car = new Car();
                    Console.Write("Enter brand ID: ");
                    car.BrandId = int.Parse(Console.ReadLine());
                    Console.Write("Enter model ID: ");
                    car.ModellId = int.Parse(Console.ReadLine());
                    Console.Write("Enter price: ");
                    car.Price = int.Parse(Console.ReadLine());
                    Console.Write("Enter fuel: ");
                    car.Fuel = Console.ReadLine();
                    Console.Write("Enter colour: ");
                    car.Colour = Console.ReadLine();
                    carhouseBusiness.AddCar(car);
                    Console.WriteLine("Done.");
                    break;
                case 4:
                    Client client = new Client();
                    Console.Write("Enter client name: ");
                    client.ClientName = Console.ReadLine();
                    Console.Write("Enter client phone: ");
                    client.Phone = Console.ReadLine();
                    carhouseBusiness.AddClient(client);
                    Console.WriteLine("Done.");
                    break;
                case 5:
                    Order order = new Order();
                    Console.Write("Enter client ID: ");
                    order.ClientId = int.Parse(Console.ReadLine());
                    Console.Write("Enter car ID: ");
                    order.CarId = int.Parse(Console.ReadLine());
                    carhouseBusiness.AddOrder(order);
                    Console.WriteLine("Done.");
                    break;
                default:
                    break;
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Актуализира се запис в базата данни.
        /// </summary>
        /// <remarks>
        /// Актуализира се запис в избраната чрез въвеждане върху потребителския интерфейс таблица.
        /// </remarks>
        /// <list type="table">
        /// <term>model</term>
        /// <description>
        /// Актуализира запис в таблица <c>Modell</c> като се въведе 
        /// идентификационния номер на модела и следователно данните, с които да го актуализираме.
        /// </description>
        /// <term>brand</term>
        /// <description>
        /// Актуализира запис в таблица <c>Brand</c> като се въведе 
        /// идентификационния номер на марката и следователно данните, с които да я актуализираме.
        /// </description>
        /// <term>car</term>
        /// <description>
        /// Актуализира запис в таблица <c>Car</c> като се въведе 
        /// идентификационния номер на колата и следователно данните, с които да я актуализираме.
        /// </description>
        /// <term>client</term>
        /// <description>
        /// Актуализира запис в таблица <c>Client</c> като се въведе 
        /// идентификационния номер на клиента и следователно данните, с които да го актуализираме.
        /// </description>
        /// <term>order</term>
        /// <description>
        /// Актуализира запис в таблица <c>Order</c> като се въведе 
        /// идентификационния номер на поръчката и следователно данните, с които да я актуализираме.
        /// </description>
        /// </list>
        private void Update()
        {
            Console.WriteLine("Choose what to update:");
            Console.WriteLine("1. Model");
            Console.WriteLine("2. Brand");
            Console.WriteLine("3. Car");
            Console.WriteLine("4. Client");
            Console.WriteLine("5. Order");
            Console.WriteLine();
            Console.Write("Your choice (number): ");
            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine();
            switch (choice)
            {
                case 1:
                    Console.Write("Enter model ID to update: ");
                    int modellid = int.Parse(Console.ReadLine());
                    Modell modell = carhouseBusiness.GetModel(modellid);
                    if (modell != null)
                    {
                        Console.Write("Enter model name: ");
                        modell.ModellName = Console.ReadLine();
                        carhouseBusiness.UpdateModel(modell);
                        Console.WriteLine("Done.");
                    }
                    else
                    {
                        Console.WriteLine("Model not found.");
                    }
                    break;
                case 2:
                    Console.Write("Enter ID to update: ");
                    int brandid = int.Parse(Console.ReadLine());
                    Brand brand = carhouseBusiness.GetBrand(brandid);

                    if (brand != null)
                    {
                        Console.Write("Enter name: ");
                        brand.BrandName = Console.ReadLine();
                        carhouseBusiness.UpdateBrand(brand);
                        Console.WriteLine("Done.");
                    }
                    else
                    {
                        Console.WriteLine("Brand not found.");
                    }
                    break;
                case 3:
                    Console.Write("Enter ID to update: ");
                    int carid = int.Parse(Console.ReadLine());
                    Car car = carhouseBusiness.GetCar(carid);

                    if (car != null)
                    {
                        Console.Write("Enter model id: ");
                        car.ModellId = int.Parse(Console.ReadLine());
                        Console.Write("Enter brand id: ");
                        car.BrandId = int.Parse(Console.ReadLine());
                        Console.Write("Enter price: ");
                        car.Price = int.Parse(Console.ReadLine());
                        Console.Write("Enter fuel: ");
                        car.Fuel = Console.ReadLine();
                        Console.Write("Enter colour: ");
                        car.Colour = Console.ReadLine();
                        carhouseBusiness.UpdateCar(car);
                        Console.WriteLine("Done.");
                    }
                    else
                    {
                        Console.WriteLine("Car not found.");
                    }
                    break;
                case 4:
                    Console.Write("Enter ID to update: ");
                    int clientid = int.Parse(Console.ReadLine());
                    Client client = carhouseBusiness.GetClient(clientid);

                    if (client != null)
                    {
                        Console.Write("Enter client name");
                        client.ClientName = Console.ReadLine();
                        Console.Write("Enter client phone: ");
                        client.Phone = Console.ReadLine();
                        carhouseBusiness.UpdateClient(client);
                        Console.WriteLine("Done.");
                    }
                    else
                    {
                        Console.WriteLine("Client not found.");
                    }
                    break;
                case 5:
                    Console.Write("Enter ID to update: ");
                    int orderid = int.Parse(Console.ReadLine());
                    Order order = carhouseBusiness.GetOrder(orderid);

                    if (order != null)
                    {
                        Console.Write("Enter client id: ");
                        order.ClientId = int.Parse(Console.ReadLine());
                        Console.Write("Enter car id: ");
                        order.CarId = int.Parse(Console.ReadLine());
                        carhouseBusiness.UpdateOrder(order);
                        Console.WriteLine("Done.");
                    }
                    else
                    {
                        Console.WriteLine("Order not found.");
                    }
                    break;
                default:
                    break;
            }
            Console.WriteLine();
        }

       
        /// <summary>
        /// Изтрива се запис от базата данни по ID.
        /// </summary>
        /// <remarks>
        /// Изтрива се запис от избраната чрез въвеждане върху потребителския интерфейс таблица.
        /// </remarks>
        /// <list type="table">
        /// <term>model</term>
        /// <description>
        /// Изтрива запис от таблица <c>Modell</c> като се въведе 
        /// идентификационния номер на модела.
        /// </description>
        /// <term>brand</term>
        /// <description>
        /// Изтрива запис от таблица <c>Brand</c> като се въведе 
        /// идентификационния номер на марката.
        /// </description>
        /// <term>car</term>
        /// <description>
        /// Изтрива запис от таблица <c>Car</c> като се въведе 
        /// идентификационния номер на колата.
        /// </description>
        /// <term>client</term>
        /// <description>
        /// Изтрива запис от таблица <c>Client</c> като се въведе 
        /// идентификационния номер на клиента.
        /// </description>
        /// <term>order</term>
        /// <description>
        /// Изтрива запис от таблица <c>Order</c> като се въведе 
        /// идентификационния номер на поръката.
        /// </description>
        /// </list>
        private void Delete()
        {
            Console.WriteLine("Choose what to delete:");
            Console.WriteLine("1. Model");
            Console.WriteLine("2. Brand");
            Console.WriteLine("3. Car");
            Console.WriteLine("4. Client");
            Console.WriteLine("5. Order");
            Console.WriteLine();
            Console.Write("Your choice: ");
            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine();
            switch (choice)
            {
                case 1:
                    Console.Write("Enter ID to delete: ");
                    int modelid = int.Parse(Console.ReadLine());
                    Modell modell = carhouseBusiness.GetModel(modelid);
                    if (modell != null)
                    {
                        carhouseBusiness.DeleteModel(modelid);
                        Console.WriteLine("Done.");
                    }
                    else
                    {
                        Console.WriteLine("Model not found.");
                    }
                    break;
                case 2:
                    Console.Write("Enter ID to delete: ");
                    int brandid = int.Parse(Console.ReadLine());
                    Brand brand = carhouseBusiness.GetBrand(brandid);
                    if (brand != null)
                    {
                        carhouseBusiness.DeleteBrand(brandid);
                        Console.WriteLine("Done.");
                    }
                    else
                    {
                        Console.WriteLine("Brand not found.");
                    }
                    break;
                case 3:
                    Console.Write("Enter ID to delete: ");
                    int carid = int.Parse(Console.ReadLine());
                    Car car = carhouseBusiness.GetCar(carid);
                    if (car != null)
                    {
                        carhouseBusiness.DeleteCar(carid);
                        Console.WriteLine("Done.");
                    }
                    else
                    {
                        Console.WriteLine("Car not found.");
                    }
                    break;
                case 4:
                    Console.Write("Enter ID to delete: ");
                    int clientid = int.Parse(Console.ReadLine());
                    Client client = carhouseBusiness.GetClient(clientid);
                    if (client != null)
                    {
                        carhouseBusiness.DeleteClient(clientid);
                        Console.WriteLine("Done.");
                    }
                    else
                    {
                        Console.WriteLine("Client not found.");
                    }
                    break;
                case 5:
                    Console.Write("Enter ID to delete: ");
                    int orderid = int.Parse(Console.ReadLine());
                    Order order = carhouseBusiness.GetOrder(orderid);
                    if (order != null)
                    {
                        carhouseBusiness.DeleteOrder(orderid);
                        Console.WriteLine("Done.");
                    }
                    else
                    {
                        Console.WriteLine("Order not found.");
                    }
                    break;
                default:
                    break;
            }
            
            Console.WriteLine();
        }

        /// <summary>
        /// Извежда се запис от базата данни по ID.
        /// </summary>
        /// <remarks>
        /// Извежда се запис от избраната чрез въвеждане върху потребителския интерфейс таблица.
        /// </remarks>
        /// <list type="table">
        /// <term>model</term>
        /// <description>
        /// Извежда запис от таблица <c>Modell</c> като се въведе 
        /// идентификационния номер на модела.
        /// </description>
        /// <term>brand</term>
        /// <description>
        /// Извежда запис от таблица <c>Brand</c> като се въведе 
        /// идентификационния номер на марката.
        /// </description>
        /// <term>car</term>
        /// <description>
        /// Извежда запис от таблица <c>Car</c> като се въведе 
        /// идентификационния номер на колата.
        /// </description>
        /// <term>client</term>
        /// <description>
        /// Извежда запис от таблица <c>Client</c> като се въведе 
        /// идентификационния номер на клиента.
        /// </description>
        /// <term>order</term>
        /// <description>
        /// Извежда запис от таблица <c>Order</c> като се въведе 
        /// идентификационния номер на поръката.
        /// </description>
        /// </list>
        private void Fetch()
        {
            Console.WriteLine("Choose what to fetch:");
            Console.WriteLine("1. Model");
            Console.WriteLine("2. Brand");
            Console.WriteLine("3. Car");
            Console.WriteLine("4. Client");
            Console.WriteLine("5. Order");
            Console.WriteLine();
            Console.Write("Your choice (number): ");
            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine();
            switch (choice)
            {
                case 1:
                    Console.Write("Enter model ID to fetch: ");
                    int modelid = int.Parse(Console.ReadLine());
                    Modell modell = carhouseBusiness.GetModel(modelid);
                    if (modell != null)
                    {
                        Console.WriteLine(new string('-', 40));
                        Console.WriteLine("Model ID: " + modell.ModellId);
                        Console.WriteLine("Model Name: " + modell.ModellName);
                        Console.WriteLine(new string('-', 40));
                    }
                    else
                    {
                        Console.WriteLine("Model not found.");
                    }
                    break;
                case 2:
                    Console.Write("Enter brand ID to fetch: ");
                    int brandid = int.Parse(Console.ReadLine());
                    Brand brand = carhouseBusiness.GetBrand(brandid);
                    if (brand != null)
                    {
                        Console.WriteLine(new string('-', 40));
                        Console.WriteLine("Brand ID: " + brand.BrandId);
                        Console.WriteLine("Brand Name: " + brand.BrandName);
                        Console.WriteLine(new string('-', 40));
                    }
                    else
                    {
                        Console.WriteLine("Brand not found.");
                    }
                    break;
                case 3:
                    Console.Write("Enter car ID to fetch: ");
                    int carid = int.Parse(Console.ReadLine());
                    Car car = carhouseBusiness.GetCar(carid);
                    if (car != null)
                    {
                        Modell carmodell = carhouseBusiness.GetModel(car.ModellId);
                        Brand carbrand = carhouseBusiness.GetBrand(car.BrandId);
                        Console.WriteLine(new string('-', 40));
                        Console.WriteLine("Car ID: {0}", car.CarId);
                        Console.WriteLine("Car Name: {0} {1}", carbrand.BrandName, carmodell.ModellName);
                        Console.WriteLine("Price: {0} euros", car.Price);
                        Console.WriteLine("Fuel: {0}", car.Fuel);
                        Console.WriteLine("Colour: {0}", car.Colour);
                        Console.WriteLine(new string('-', 40));
                    }
                    else
                    {
                        Console.WriteLine("Car not found.");
                    }
                    break;
                case 4:
                    Console.Write("Enter client ID to fetch: ");
                    int clientid = int.Parse(Console.ReadLine());
                    Client client = carhouseBusiness.GetClient(clientid);
                    if (client != null)
                    {
                        Console.WriteLine(new string('-', 40));
                        Console.WriteLine("Client ID: " + client.ClientId);
                        Console.WriteLine("Client Name: " + client.ClientName);
                        Console.WriteLine("Client Phone: " + client.Phone);
                        Console.WriteLine(new string('-', 40));
                    }
                    else
                    {
                        Console.WriteLine("Client not found.");
                    }
                    break;
                case 5:
                    Console.Write("Enter order ID to fetch: ");
                    int orderid = int.Parse(Console.ReadLine());
                    Order order = carhouseBusiness.GetOrder(orderid);
                    if (order != null)
                    {
                        Car ordercar = carhouseBusiness.GetCar(order.CarId);
                        Modell ordermodell = carhouseBusiness.GetModel(ordercar.ModellId);
                        Brand orderbrand = carhouseBusiness.GetBrand(ordercar.BrandId);
                        Client orderclient = carhouseBusiness.GetClient(order.ClientId);
                        Console.WriteLine(new string('-', 40));
                        Console.WriteLine("Order ID: {0}", order.OrderId);
                        Console.WriteLine("Car Name: {0} {1}", orderbrand.BrandName, ordermodell.ModellName);
                        Console.WriteLine("Client Name: {0}", orderclient.ClientName);
                        Console.WriteLine(new string('-', 40));
                    }
                    else
                    {
                        Console.WriteLine("Order not found.");
                    }
                    break;
                default:
                    break;
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Извеждат се всички записи от дадена таблица в базата данни.
        /// </summary>
        /// <list type="table">
        /// <term>model</term>
        /// <description>
        /// Извеждат се всички записи от таблица <c>Modell</c>.
        /// </description>
        /// <term>brand</term>
        /// <description>
        /// Извеждат се всички записи от таблица <c>Brand</c>.
        /// </description>
        /// <term>car</term>
        /// <description>
        /// Извеждат се всички записи от таблица <c>Car</c>.
        /// </description>
        /// <term>client</term>
        /// <description>
        /// Извеждат се всички записи от таблица <c>Client</c>.
        /// </description>
        /// <term>order</term>
        /// <description>
        /// Извеждат се всички записи от таблица <c>Order</c>.
        /// </description>
        /// </list>
        private void ListAll()
        {
            Console.WriteLine("Choose what to list:");
            Console.WriteLine("1. Models");
            Console.WriteLine("2. Brands");
            Console.WriteLine("3. Cars");
            Console.WriteLine("4. Clients");
            Console.WriteLine("5. Orders");
            Console.WriteLine();
            Console.Write("Your choice (number): ");
            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine();
            switch (choice)
            {
                case 1:
                    Console.WriteLine(new string('-', 40));
                    Console.WriteLine(new string(' ', 16) + "ALL MODELS" + new string(' ', 16));
                    Console.WriteLine(new string('-', 40));
                    var model = carhouseBusiness.GetAllModels();
                    foreach (var item in model)
                    {
                        Console.WriteLine("{0} {1}", item.ModellId, item.ModellName);
                    }
                    break;
                case 2:
                    Console.WriteLine(new string('-', 40));
                    Console.WriteLine(new string(' ', 16) + "ALL BRANDS" + new string(' ', 16));
                    Console.WriteLine(new string('-', 40));
                    var brand = carhouseBusiness.GetAllBrands();
                    foreach (var item in brand)
                    {
                        Console.WriteLine("{0} {1}", item.BrandId, item.BrandName);
                    }
                    break;
                case 3:
                    Console.WriteLine(new string('-', 40));
                    Console.WriteLine(new string(' ', 16) + "ALL CARS" + new string(' ', 16));
                    Console.WriteLine(new string('-', 40));
                    var car = carhouseBusiness.GetAllCars();
                    foreach (var item in car)
                    {
                        Modell modell = carhouseBusiness.GetModel(item.ModellId);
                        Brand carbrand = carhouseBusiness.GetBrand(item.BrandId);
                        Console.WriteLine("{0}. {1} {2} ", item.CarId, carbrand.BrandName, modell.ModellName);
                        Console.WriteLine("Price: {0} euros", item.Price);
                        Console.WriteLine("Fuel: {0}", item.Fuel);
                        Console.WriteLine("Colour: {0}", item.Colour);
                        Console.WriteLine();
                    }
                    break;
                case 4:
                    Console.WriteLine(new string('-', 40));
                    Console.WriteLine(new string(' ', 16) + "ALL CLIENTS" + new string(' ', 16));
                    Console.WriteLine(new string('-', 40));
                    var client = carhouseBusiness.GetAllClients();
                    foreach (var item in client)
                    {
                        Console.WriteLine("{0}. {1}", item.ClientId, item.ClientName);
                        Console.WriteLine("Phone: {0}", item.Phone);
                    }
                    break;
                case 5:
                    Console.WriteLine(new string('-', 40));
                    Console.WriteLine(new string(' ', 16) + "ALL ORDERS" + new string(' ', 16));
                    Console.WriteLine(new string('-', 40));
                    var order = carhouseBusiness.GetAllOrders();
                    foreach (var item in order)
                    {
                        Client orderclient = carhouseBusiness.GetClient(item.ClientId);
                        Car ordercar = carhouseBusiness.GetCar(item.CarId);
                        Brand orderbrand = carhouseBusiness.GetBrand(ordercar.BrandId);
                        Modell modell = carhouseBusiness.GetModel(ordercar.ModellId);
                        Console.WriteLine("{0}. {1} {2} - {3} ", item.OrderId, orderbrand.BrandName, modell.ModellName, orderclient.ClientName);
                        Console.WriteLine();
                    }
                    break;
                default:
                    break;
            }
            Console.WriteLine();
        }
    }
}
