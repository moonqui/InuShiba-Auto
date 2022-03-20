using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business;
using Data.Model;

namespace CarHouse
{
    public partial class Form1 : Form
    {
        private CarHouseBusiness carhouseBusiness = new CarHouseBusiness();
        public Form1()
        {
            InitializeComponent();
        }

        //Car Clear
        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            richTextBox1.Clear();
        }

        //Car Add
        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            if (textBox1.Text != "")
            {
                richTextBox1.Text = "Do not enter an ID! \nThe program will give each car a unique ID on its own.";
            }
            else
            {
                if (textBox3.Text == "" || textBox2.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
                {
                    richTextBox1.Text = "All fields are required!";
                }
                else
                {
                    var models = carhouseBusiness.GetAllModels();
                    int br = 0;
                    foreach (var item in models)
                    {
                        if (int.Parse(textBox2.Text) == item.ModellId)
                        {
                            br++;
                        }
                    }
                    var brands = carhouseBusiness.GetAllBrands();
                    int br2 = 0;
                    foreach (var item in brands)
                    {
                        if (int.Parse(textBox3.Text) == item.BrandId)
                        {
                            br2++;
                        }
                    }
                    if (br > 0 && br2 > 0)
                    {
                        Car car = new Car();
                        car.BrandId = int.Parse(textBox3.Text);
                        car.ModellId = int.Parse(textBox2.Text);
                        car.Price = int.Parse(textBox4.Text);
                        car.Fuel = textBox5.Text;
                        car.Colour = textBox6.Text;
                        carhouseBusiness.AddCar(car);
                        richTextBox1.Text = "Done!";
                    }
                    else
                    {
                        richTextBox1.Text = "Brand or model does not exist.";
                    }
                }
            }
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        //Car Update
        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            if (textBox1.Text == "")
            {
                richTextBox1.Text = "Enter car ID!";
            }
            else
            {
                int carid = int.Parse(textBox1.Text);
                Car car = carhouseBusiness.GetCar(carid);
                if (car != null)
                {
                    if (textBox3.Text != "" || textBox2.Text != "" || textBox4.Text != "" || textBox5.Text != "" || textBox6.Text != "")
                    {
                        var models = carhouseBusiness.GetAllModels();
                        int br = 0;
                        foreach (var item in models)
                        {
                            if (int.Parse(textBox2.Text) == item.ModellId)
                            {
                                br++;
                            }
                        }
                        var brands = carhouseBusiness.GetAllBrands();
                        int br2 = 0;
                        foreach (var item in brands)
                        {
                            if (int.Parse(textBox3.Text) == item.BrandId)
                            {
                                br2++;
                            }
                        }
                        if (br >0 && br2>0)
                        {
                            car.BrandId = int.Parse(textBox3.Text);
                            car.ModellId = int.Parse(textBox2.Text);
                            car.Price = int.Parse(textBox4.Text);
                            car.Fuel = textBox5.Text;
                            car.Colour = textBox6.Text;
                            carhouseBusiness.UpdateCar(car);
                            textBox1.Clear();
                            textBox2.Clear();
                            textBox3.Clear();
                            textBox4.Clear();
                            textBox5.Clear();
                            textBox6.Clear();
                            richTextBox1.Text = "Done!";
                        }
                        else
                        {
                            richTextBox1.Text = "Brand or model does not exist.";
                        }
                    }
                    else
                    {
                        richTextBox1.Text = "All fields required!";
                    }
                }
                else
                {
                    richTextBox1.Text = "Car not found!";
                }
            }
        }

        //Car Delete
        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            if (textBox1.Text == "")
            {
                richTextBox1.Text = "Enter car ID!";
            }
            else
            {
                int carid = int.Parse(textBox1.Text);
                Car car = carhouseBusiness.GetCar(carid);
                if (car != null)
                {
                    carhouseBusiness.DeleteCar(carid);
                    richTextBox1.Text = "Done.";
                    textBox1.Clear();
                }
                else
                {
                    richTextBox1.Text = "Car not found.";
                    textBox1.Clear();
                }
            }
        }

        //Car Fetch
        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                richTextBox1.Text = "Enter car ID!";
            }
            else
            {
                int carid = int.Parse(textBox1.Text);
                Car car = carhouseBusiness.GetCar(carid);
                if (car != null)
                {
                    Modell carmodell = carhouseBusiness.GetModel(car.ModellId);
                    Brand carbrand = carhouseBusiness.GetBrand(car.BrandId);
                    richTextBox1.Text = car.CarId + ". " + carbrand.BrandName + " "+ carmodell.ModellName + "\nPrice: " +car.Price +"euros \nFuel: "+car.Fuel+"\nColour: "+car.Colour;
                }
                else
                {
                    richTextBox1.Text = "Car not found.";
                }
                textBox1.Clear();
            }
        }

        //Car List All
        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            var car = carhouseBusiness.GetAllCars();
            richTextBox1.Text = "All Cars" + "\n" + new string('-', 16);
            foreach (var item in car)
            {
                Modell carmodell = carhouseBusiness.GetModel(item.ModellId);
                Brand carbrand = carhouseBusiness.GetBrand(item.BrandId);
                richTextBox1.Text = richTextBox1.Text + "\n" + item.CarId + ". " + carbrand.BrandName+ " "+ carmodell.ModellName+ "\nPrice: " + item.Price + " euros \nFuel: " +item.Fuel+"\nColour: "+item.Colour + "\n";
            }
        }

        //Brand Add
        private void button12_Click(object sender, EventArgs e)
        {
            richTextBox2.Clear();
            if (textBox12.Text != "")
            {
                richTextBox2.Text = "Do not enter an ID! \nThe program will give each brand a unique ID on its own.";
            }
            else
            {
                var name = textBox10.Text;
                var brand = carhouseBusiness.GetAllBrands();
                int br = 0;
                foreach (var item in brand)
                {
                    if (item.BrandName == name)
                    {
                        br++;
                    }
                }
                if (br != 0)
                {
                    richTextBox2.Text = "Brand already exists!";
                }
                else
                {
                    Brand brand1 = new Brand();
                    brand1.BrandName = name;
                    carhouseBusiness.AddBrand(brand1);
                    richTextBox2.Text = "Done!";
                }
            }
            textBox12.Clear();
            textBox10.Clear();
        }

        //Brand Update
        private void button11_Click(object sender, EventArgs e)
        {
            richTextBox2.Clear();
            if (textBox12.Text == "")
            {
                richTextBox2.Text = "Enter brand ID!";
            }
            else
            {
                int brandid = int.Parse(textBox12.Text);
                Brand brand = carhouseBusiness.GetBrand(brandid);
                if (brand != null)
                {
                    if (textBox10.Text != "")
                    {
                        brand.BrandName = textBox10.Text;
                        carhouseBusiness.UpdateBrand(brand);
                        textBox10.Clear();
                        textBox12.Clear();
                        richTextBox2.Text = "Done!";
                    }
                    else
                    {
                        richTextBox2.Text = "Enter brand name!";
                    }
                }
                else
                {
                    richTextBox2.Text = "Brand not found!";
                }
            }
        }

        //Brand Delete
        private void button10_Click(object sender, EventArgs e)
        {
            richTextBox2.Clear();
            if (textBox12.Text == "")
            {
                richTextBox2.Text = "Enter brand ID!";
            }
            else
            {
                int brandid = int.Parse(textBox12.Text);
                Brand brand = carhouseBusiness.GetBrand(brandid);
                if (brand != null)
                {
                    carhouseBusiness.DeleteBrand(brandid);
                    richTextBox2.Text = "Done.";
                    textBox12.Clear();
                }
                else
                {
                    richTextBox2.Text = "Brand not found.";
                    textBox12.Clear();
                }
            }
        }

        //Brand Fetch
        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox12.Text == "")
            {
                richTextBox2.Text = "Enter brand ID!";
            }
            else
            {
                int brandid = int.Parse(textBox12.Text);
                Brand brand = carhouseBusiness.GetBrand(brandid);
                if (brand != null)
                {
                    richTextBox2.Text = "Brand ID: " + brand.BrandId + "\nBrand Name: " + brand.BrandName;
                }
                else
                {
                    richTextBox2.Text = "Brand not found.";
                }
                textBox12.Clear();
            }
        }

        //Brand List All
        private void button8_Click(object sender, EventArgs e)
        {
            richTextBox2.Clear();

            var brand = carhouseBusiness.GetAllBrands();
            richTextBox2.Text = "All Brands" + "\n" + new string('-', 16);
            foreach (var item in brand)
            {
                richTextBox2.Text = richTextBox2.Text + "\n" + item.BrandId + ". " + item.BrandName;
            }
        }

        //Brand Clear
        private void button7_Click(object sender, EventArgs e)
        {
            textBox10.Clear();
            textBox12.Clear();
            richTextBox2.Clear();
        }

        //Model Add
        private void button18_Click(object sender, EventArgs e)
        {
            richTextBox3.Clear();
            if (textBox8.Text != "")
            {
                richTextBox3.Text = "Do not enter an ID! \nThe program will give each model a unique ID on its own.";
            }
            else
            {
                var name = textBox7.Text;
                var model = carhouseBusiness.GetAllModels();
                int br = 0;
                foreach (var item in model)
                {
                    if (item.ModellName == name)
                    {
                        br++;
                    }
                }
                if (br != 0)
                {
                    richTextBox3.Text = "Model already exists!";
                }
                else
                {
                    Modell modell = new Modell();
                    modell.ModellName = name;
                    carhouseBusiness.AddModel(modell);
                    richTextBox3.Text = "Done!";
                }
            }
            textBox7.Clear();
            textBox8.Clear();
        }

        //Model Update
        private void button17_Click(object sender, EventArgs e)
        {
            richTextBox3.Clear();
            if (textBox8.Text == "")
            {
                richTextBox3.Text = "Enter model ID!";
            }
            else
            {
                int modellid = int.Parse(textBox8.Text);
                Modell modell = carhouseBusiness.GetModel(modellid);
                if (modell != null)
                {
                    if (textBox7.Text != "")
                    {
                        modell.ModellName = textBox7.Text;
                        carhouseBusiness.UpdateModel(modell);
                        textBox8.Clear();
                        textBox7.Clear();
                        richTextBox3.Text = "Done!";
                    }
                    else
                    {
                        richTextBox3.Text = "Enter model name!";
                    }
                }
                else
                {
                    richTextBox3.Text = "Model not found!";
                }
            }
        }

        //Model Delete
        private void button16_Click(object sender, EventArgs e)
        {
            richTextBox3.Clear();
            if (textBox8.Text == "")
            {
                richTextBox3.Text = "Enter model ID!";
            }
            else
            {
                int modelid = int.Parse(textBox8.Text);
                Modell modell = carhouseBusiness.GetModel(modelid);
                if (modell != null)
                {
                    carhouseBusiness.DeleteModel(modelid);
                    richTextBox3.Text = "Done.";
                    textBox8.Clear();
                }
                else
                {
                    textBox8.Clear();
                    richTextBox3.Text = "Model not found.";
                }
            }
        }

        //Model Fetch
        private void button15_Click(object sender, EventArgs e)
        {
            if (textBox8.Text == "")
            {
                richTextBox3.Text = "Enter model ID!";
            }
            else
            {
                int modelid = int.Parse(textBox8.Text);
                Modell modell = carhouseBusiness.GetModel(modelid);
                if (modell != null)
                {
                    richTextBox3.Text = "Model ID: " + modell.ModellId + "\nModel Name: " + modell.ModellName;
                }
                else
                {
                    richTextBox3.Text = "Model not found.";
                }
                textBox8.Clear();
            }
        }

        //Model List All
        private void button14_Click(object sender, EventArgs e)
        {
            richTextBox3.Clear();

            var model = carhouseBusiness.GetAllModels();
            richTextBox3.Text = "All Models" + "\n" + new string('-', 16);
            foreach (var item in model)
            {
                richTextBox3.Text = richTextBox3.Text + "\n" + item.ModellId + ". " + item.ModellName;
            }
        }

        //Model Clear
        private void button13_Click(object sender, EventArgs e)
        {
            textBox8.Clear();
            textBox7.Clear();
            richTextBox3.Clear();
        }

        //Client Add
        private void button24_Click(object sender, EventArgs e)
        {
            richTextBox4.Clear();
            if (textBox11.Text != "")
            {
                richTextBox4.Text = "Do not enter an ID! \nThe program will give each client a unique ID on its own.";
            }
            else
            {
                if (textBox9.Text == "" || textBox13.Text == "")
                {
                    richTextBox4.Text = "All fields are required!";
                }
                else
                {
                    Client client = new Client();
                    client.ClientName = textBox9.Text;
                    client.Phone = textBox13.Text;
                    carhouseBusiness.AddClient(client);
                    richTextBox4.Text = "Done!";
                }
            }
            textBox11.Clear();
            textBox9.Clear();
            textBox13.Clear();
        }

        //Client Update
        private void button23_Click(object sender, EventArgs e)
        {
            richTextBox4.Clear();
            if (textBox11.Text == "")
            {
                richTextBox4.Text = "Enter client ID!";
            }
            else
            {
                int clientid = int.Parse(textBox11.Text);
                Client client = carhouseBusiness.GetClient(clientid);
                if (client != null)
                {
                    if (textBox13.Text != "" || textBox9.Text != "")
                    {
                        client.ClientName = textBox9.Text;
                        client.Phone = textBox13.Text;
                        carhouseBusiness.UpdateClient(client);
                        textBox11.Clear();
                        textBox9.Clear();
                        textBox13.Clear();
                        richTextBox4.Text = "Done!";
                    }
                    else
                    {
                        richTextBox4.Text = "All fields required!";
                    }
                }
                else
                {
                    richTextBox4.Text = "Client not found!";
                }
            }
        }

        //Client Delete
        private void button22_Click(object sender, EventArgs e)
        {
            richTextBox4.Clear();
            if (textBox11.Text == "")
            {
                richTextBox4.Text = "Enter client ID!";
            }
            else
            {
                int clientid = int.Parse(textBox11.Text);
                Client client = carhouseBusiness.GetClient(clientid);
                if (client != null)
                {
                    carhouseBusiness.DeleteClient(clientid);
                    richTextBox4.Text = "Done.";
                    textBox11.Clear();
                }
                else
                {
                    richTextBox4.Text = "Client not found.";
                    textBox11.Clear();
                }
            }
        }

        //Client Fetch
        private void button21_Click(object sender, EventArgs e)
        {
            if (textBox11.Text == "")
            {
                richTextBox4.Text = "Enter client ID!";
            }
            else
            {
                int clientid = int.Parse(textBox11.Text);
                Client client = carhouseBusiness.GetClient(clientid);
                if (client != null)
                {
                    richTextBox4.Text = client.ClientId + ". " + client.ClientName + "\nPhone: " + client.Phone ;
                }
                else
                {
                    richTextBox4.Text = "Client not found.";
                }
                textBox11.Clear();
            }
        }

        //Client List All
        private void button20_Click(object sender, EventArgs e)
        {
            richTextBox4.Clear();

            var client = carhouseBusiness.GetAllClients();
            richTextBox4.Text = "All Clients" + "\n" + new string('-', 16);
            foreach (var item in client)
            {
                richTextBox4.Text = richTextBox4.Text + "\n" + item.ClientId + ". " + item.ClientName + "\nPhone: " + item.Phone + "\n";
            }
        }

        //Client Clear
        private void button19_Click(object sender, EventArgs e)
        {
            richTextBox4.Clear();
            textBox11.Clear();
            textBox9.Clear();
            textBox13.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //Order Add
        private void button30_Click(object sender, EventArgs e)
        {
            richTextBox5.Clear();
            if (textBox16.Text != "")
            {
                richTextBox5.Text = "Do not enter an ID! \nThe program will give each order a unique ID on its own.";
            }
            else
            {
                if (textBox15.Text == "" || textBox14.Text == "")
                {
                    richTextBox5.Text = "All fields are required!";
                }
                else
                {
                    var cars = carhouseBusiness.GetAllCars();
                    int br = 0;
                    foreach (var item in cars)
                    {
                        if (int.Parse(textBox14.Text) == item.CarId)
                        {
                            br++;
                        }
                    }
                    var clients = carhouseBusiness.GetAllClients();
                    int br2 = 0;
                    foreach (var item in clients)
                    {
                        if (int.Parse(textBox15.Text) == item.ClientId)
                        {
                            br2++;
                        }
                    }
                    if (br > 0 && br2 > 0)
                    {
                        Order order = new Order();
                        order.ClientId = int.Parse(textBox15.Text);
                        order.CarId = int.Parse(textBox14.Text);
                        carhouseBusiness.AddOrder(order);
                        richTextBox5.Text = "Done!";
                    }
                    else
                    {
                        richTextBox5.Text = "Car or client does not exist!";
                    }
                }
            }
            textBox14.Clear();
            textBox15.Clear();
            textBox16.Clear();
        }

        //Order Update
        private void button29_Click(object sender, EventArgs e)
        {
            richTextBox5.Clear();
            if (textBox16.Text == "")
            {
                richTextBox5.Text = "Enter order ID!";
            }
            else
            {
                int orderid = int.Parse(textBox16.Text);
                Order order = carhouseBusiness.GetOrder(orderid);
                if (order != null)
                {
                    if (textBox14.Text != "" || textBox15.Text != "")
                    {
                        var cars = carhouseBusiness.GetAllCars();
                        int br = 0;
                        foreach (var item in cars)
                        {
                            if (int.Parse(textBox14.Text) == item.CarId)
                            {
                                br++;
                            }
                        }
                        var clients = carhouseBusiness.GetAllClients();
                        int br2 = 0;
                        foreach (var item in clients)
                        {
                            if (int.Parse(textBox15.Text) == item.ClientId)
                            {
                                br2++;
                            }
                        }
                        if (br>0 && br2>0)
                        {
                            order.ClientId = int.Parse(textBox15.Text);
                            order.CarId = int.Parse(textBox14.Text);
                            carhouseBusiness.UpdateOrder(order);
                            textBox15.Clear();
                            textBox14.Clear();
                            textBox16.Clear();
                            richTextBox5.Text = "Done!";
                        }
                        else
                        {
                            richTextBox5.Text = "Car or client does not exist!";
                        }
                    }
                    else
                    {
                        richTextBox5.Text = "All fields required!";
                    }
                }
                else
                {
                    richTextBox5.Text = "Order not found!";
                }
            }
            textBox14.Clear();
            textBox15.Clear();
            textBox16.Clear();
        }

        //Order Delete
        private void button28_Click(object sender, EventArgs e)
        {
            richTextBox5.Clear();
            if (textBox16.Text == "")
            {
                richTextBox5.Text = "Enter order ID!";
            }
            else
            {
                int orderid = int.Parse(textBox16.Text);
                Order order = carhouseBusiness.GetOrder(orderid);
                if (order != null)
                {
                    carhouseBusiness.DeleteOrder(orderid);
                    richTextBox5.Text = "Done.";
                    textBox16.Clear();
                }
                else
                {
                    richTextBox5.Text = "Order not found.";
                    textBox16.Clear();
                }
            }
        }

        //Order Fetch
        private void button27_Click(object sender, EventArgs e)
        {
            richTextBox5.Clear();
            if (textBox16.Text == "")
            {
                richTextBox5.Text = "Enter order ID!";
            }
            else
            {
                int orderid = int.Parse(textBox16.Text);
                Order order = carhouseBusiness.GetOrder(orderid);
                if (order != null)
                {
                    Client orderclient = carhouseBusiness.GetClient(order.ClientId);
                    Car ordercar = carhouseBusiness.GetCar(order.CarId);
                    Brand orderbrand = carhouseBusiness.GetBrand(ordercar.BrandId);
                    Modell ordermodell = carhouseBusiness.GetModel(ordercar.ModellId);
                    richTextBox5.Text = richTextBox5.Text + order.OrderId + ". " + orderbrand.BrandName + " " + ordermodell.ModellName + " - " + orderclient.ClientName;
                }
                else
                {
                    richTextBox5.Text = "Order not found.";
                }
                textBox16.Clear();
            }
        }

        //Order List All
        private void button26_Click(object sender, EventArgs e)
        {
            var order = carhouseBusiness.GetAllOrders();
            richTextBox5.Text = "All Orders" + "\n" + new string('-', 16);
            foreach (var item in order)
            {
                Client orderclient = carhouseBusiness.GetClient(item.ClientId);
                Car ordercar = carhouseBusiness.GetCar(item.CarId);
                Brand orderbrand = carhouseBusiness.GetBrand(ordercar.BrandId);
                Modell ordermodell = carhouseBusiness.GetModel(ordercar.ModellId);
                richTextBox5.Text = richTextBox5.Text + "\n" + item.OrderId + ". " + orderbrand.BrandName + " " + ordermodell.ModellName + " - " + orderclient.ClientName;
            }
        }

        //Order Clear
        private void button25_Click(object sender, EventArgs e)
        {
            richTextBox5.Clear();
            textBox14.Clear();
            textBox15.Clear();
            textBox16.Clear();
        }
    }
}
