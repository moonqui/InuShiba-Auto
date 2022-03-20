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
using System.Threading;

namespace CarHouse
{
    /// <summary>
    /// Описване на потребителския интерфейс.
    /// </summary>
    /// <remarks>
    /// Представя се възможност за използване 
    /// на различни методи за работа с база данни като 
    /// добавяне, изтриване, актуализиране, извличане.
    /// </remarks>
    public partial class Form1 : Form
    {
        /// <value>
        /// <c>carhouseBusiness</c> свързва <c>Form1</c> с <c>CarHouseBusiness</c>.
        /// </value>
        /// <remarks>
        /// В текущия клас вече може да се работи с данните от клас <c>CarHouseBusiness</c>.
        /// </remarks>
        private CarHouseBusiness carhouseBusiness = new CarHouseBusiness();

        /// <summary>
        /// Инициализация на графичния интерфейс.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Добавя нов запис за кола в базата данни.
        /// </summary>
        /// <remarks>Всички textBox полета без <c>textBox1</c> в tab Cars трябва да бъдат попълнени, за да се добави нов запис.</remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //Car Add
            richTextBox1.Clear();
            if (textBox1.Text != "")
            {
                string message = "Do not enter an ID! \nThe program will give each car a unique ID on its own.";
                string title = "Warning!";
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (textBox3.Text == "" || textBox2.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
                {
                    string message = "All fields are required!";
                    string title = "Warning!";
                    MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        string message = "Brand or model does not exist.";
                        string title = "Error!";
                        MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        /// <summary>
        /// Актуализира се запис на кола в базата данни.
        /// </summary>
        /// <remarks>Трябва всички textBox полета в tab Cars да бъдат запълнени, включително и ID на колата, която искаме да актуализираме.</remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            //Car Update
            richTextBox1.Clear();
            if (textBox1.Text == "")
            {
                string message = "Enter car ID!";
                string title = "Warning!";
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                            richTextBox1.Text = "Done!";
                        }
                        else
                        {
                            string message = "Brand or model does not exist.";
                            string title = "Error!";
                            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        string message = "All fields required!";
                        string title = "Warning!";
                        MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    string message = "Car not found!";
                    string title = "Error!";
                    MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
            }
        }

        /// <summary>
        /// Изтрива се запис на кола от базата данни по ID.
        /// </summary>
        /// <remarks>За изпълнението на този метод е нужно само ID на колата(<c>CarId</c>), която желаем да изтрием.</remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            //Car Delete
            richTextBox1.Clear();
            if (textBox1.Text == "")
            {
                string message = "Enter car ID!";
                string title = "Warning!";
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int carid = int.Parse(textBox1.Text);
                Car car = carhouseBusiness.GetCar(carid);
                if (car != null)
                {
                    carhouseBusiness.DeleteCar(carid);
                    richTextBox1.Text = "Done.";
                }
                else
                {
                    string message = "Car not found.";
                    string title = "Error!";
                    MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
            }
        }

        /// <summary>
        /// Извежда се запис на кола от базата данни по ID.
        /// </summary>
        /// <remarks>За изпълнението на този метод е нужно само ID на колата (<c>CarId</c>), която желаем да изтрием.</remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            //Car Fetch
            richTextBox1.Clear();
            if (textBox1.Text == "")
            {
                string message = "Enter car ID!";
                string title = "Warning!";
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int carid = int.Parse(textBox1.Text);
                Car car = carhouseBusiness.GetCar(carid);
                if (car != null)
                {
                    Modell carmodell = carhouseBusiness.GetModel(car.ModellId);
                    Brand carbrand = carhouseBusiness.GetBrand(car.BrandId);
                    richTextBox1.Text = car.CarId + ". " + carbrand.BrandName + " "+ carmodell.ModellName + "\nPrice: " +car.Price +" euros \nFuel: "+car.Fuel+"\nColour: "+car.Colour;
                }
                else
                {
                    string message = "Car not found.";
                    string title = "Error!";
                    MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
            }
        }

        /// <summary>
        /// Извеждат се всички записи от таблица Car от базата данни.
        /// </summary>
        /// <remarks>Не е нужно да се попълва textBox поле, за да работи този метод.</remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            //Car List All
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
        /// <summary>
        /// Изчистване на всички textBox и richTextBox полета в tab Cars.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            //Car Clear
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            richTextBox1.Clear();
        }

        /// <summary>
        /// Добавя нов запис за марка в базата данни.
        /// </summary>
        /// <remarks>Всички textBox полета без <c>textBox12</c> в tab Brands трябва да бъдат попълнени, за да се добави нов запис.</remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button12_Click(object sender, EventArgs e)
        {
            //Brand Add
            richTextBox2.Clear();
            if (textBox12.Text != "")
            {
                string message = "Do not enter an ID! \nThe program will give each brand a unique ID on its own.";
                string title = "Warning!";
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var name = textBox10.Text;
                var brand = carhouseBusiness.GetAllBrands();
                int br = 0;
                foreach (var item in brand)
                {
                    if (item.BrandName == name || name == "")
                    {
                        br++;
                    }
                }
                if (br != 0)
                {
                    string message = "Brand already exists or name field is empty!";
                    string title = "Error!";
                    MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        /// <summary>
        /// Актуализира се запис на марка в базата данни.
        /// </summary>
        /// <remarks>Трябва всички textBox полета в tab Brand да бъдат запълнени, включително и ID на марката, която искаме да актуализираме.</remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button11_Click(object sender, EventArgs e)
        {
            //Brand Update
            richTextBox2.Clear();
            if (textBox12.Text == "")
            {
                string message = "Enter brand ID!";
                string title = "Warning!";
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        richTextBox2.Text = "Done!";
                    }
                    else
                    {
                        string message = "Enter brand name!";
                        string title = "Warning!";
                        MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    string message = "Brand not found!";
                    string title = "Error!";
                    MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                textBox12.Clear();
                textBox10.Clear();
            }
        }

        /// <summary>
        /// Изтрива се запис на марка от базата данни по ID.
        /// </summary>
        /// <remarks>За изпълнението на този метод е нужно само ID на марката(<c>BrandId</c>), която желаем да изтрием.</remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button10_Click(object sender, EventArgs e)
        {
            //Brand Delete
            richTextBox2.Clear();
            if (textBox12.Text == "")
            {string message = "Enter brand ID!";
                string title = "Warning!";
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int brandid = int.Parse(textBox12.Text);
                Brand brand = carhouseBusiness.GetBrand(brandid);
                if (brand != null)
                {
                    carhouseBusiness.DeleteBrand(brandid);
                    richTextBox2.Text = "Done.";
                }
                else
                {
                    string message = "Brand not found!";
                    string title = "Error!";
                    MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                textBox12.Clear();
                textBox10.Clear();
            }
        }

        /// <summary>
        /// Извежда се запис на марка от базата данни по ID.
        /// </summary>
        /// <remarks>За изпълнението на този метод е нужно само ID на марката (<c>BrandId</c>), която желаем да изтрием.</remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button9_Click(object sender, EventArgs e)
        {
            //Brand Fetch
            richTextBox2.Clear();
            if (textBox12.Text == "")
            {
                string message = "Enter brand ID!";
                string title = "Warning!";
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    string message = "Brand not found.";
                    string title = "Error!";
                    MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                textBox12.Clear();
                textBox10.Clear();
            }
        }

        /// <summary>
        /// Извеждат се всички записи от таблица Brand от базата данни.
        /// </summary>
        /// <remarks>Не е нужно да се попълва textBox поле, за да работи този метод.</remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, EventArgs e)
        {
            //Brand List All
            richTextBox2.Clear();
            var brand = carhouseBusiness.GetAllBrands();
            richTextBox2.Text = "All Brands" + "\n" + new string('-', 16);
            foreach (var item in brand)
            {
                richTextBox2.Text = richTextBox2.Text + "\n" + item.BrandId + ". " + item.BrandName;
            }
        }

        /// <summary>
        /// Изчистване на всички textBox и richTextBox полета в tab Brands.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            //Brand Clear
            textBox10.Clear();
            textBox12.Clear();
            richTextBox2.Clear();
        }

        /// <summary>
        /// Добавя нов запис за модел в базата данни.
        /// </summary>
        /// <remarks>Всички textBox полета без <c>textBox8</c> в tab Models трябва да бъдат попълнени, за да се добави нов запис.</remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button18_Click(object sender, EventArgs e)
        {
            //Model Add
            richTextBox3.Clear();
            if (textBox8.Text != "")
            {
                string message = "Do not enter an ID! \nThe program will give each model a unique ID on its own.";
                string title = "Warning!";
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var name = textBox7.Text;
                var model = carhouseBusiness.GetAllModels();
                int br = 0;
                foreach (var item in model)
                {
                    if (item.ModellName == name || name == "")
                    {
                        br++;
                    }
                }
                if (br != 0)
                {
                    string message = "Model already exists or name field is empty!";
                    string title = "Error!";
                    MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        /// <summary>
        /// Актуализира се запис на модел в базата данни.
        /// </summary>
        /// <remarks>Трябва всички textBox полета в tab Models да бъдат запълнени, включително и ID на модела, който искаме да актуализираме.</remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button17_Click(object sender, EventArgs e)
        {
            //Model Update
            richTextBox3.Clear();
            if (textBox8.Text == "")
            {
                string message = "Enter model ID!";
                string title = "Warning!";
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        richTextBox3.Text = "Done!";
                    }
                    else
                    {
                        string message = "Enter model name!";
                        string title = "Warning!";
                        MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    string message = "Model not found!";
                    string title = "Error!";
                    MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                textBox7.Clear();
                textBox8.Clear();
            }
        }

        /// <summary>
        /// Изтрива се запис на модел от базата данни по ID.
        /// </summary>
        /// <remarks>За изпълнението на този метод е нужно само ID на модела(<c>ModelId</c>), който желаем да изтрием.</remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button16_Click(object sender, EventArgs e)
        {
            //Model Delete
            richTextBox3.Clear();
            if (textBox8.Text == "")
            {
                string message = "Enter model ID!";
                string title = "Warning!";
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int modelid = int.Parse(textBox8.Text);
                Modell modell = carhouseBusiness.GetModel(modelid);
                if (modell != null)
                {
                    carhouseBusiness.DeleteModel(modelid);
                    richTextBox3.Text = "Done.";
                }
                else
                {
                    string message = "Model not found!";
                    string title = "Error!";
                    MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                textBox7.Clear();
                textBox8.Clear();
            }
        }

        /// <summary>
        /// Извежда се запис на модел от базата данни по ID.
        /// </summary>
        /// <remarks>За изпълнението на този метод е нужно само ID на модела (<c>ModelId</c>), който желаем да изтрием.</remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button15_Click(object sender, EventArgs e)
        {
            //Model Fetch
            richTextBox3.Clear();
            if (textBox8.Text == "")
            {
                string message = "Enter model ID!";
                string title = "Warning!";
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    string message = "Model not found.!";
                    string title = "Error!";
                    MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                textBox7.Clear();
                textBox8.Clear();
            }
        }

        /// <summary>
        /// Извеждат се всички записи от таблица Model от базата данни.
        /// </summary>
        /// <remarks>Не е нужно да се попълва textBox поле, за да работи този метод.</remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button14_Click(object sender, EventArgs e)
        {
            //Model List All
            richTextBox3.Clear();
            var model = carhouseBusiness.GetAllModels();
            richTextBox3.Text = "All Models" + "\n" + new string('-', 16);
            foreach (var item in model)
            {
                richTextBox3.Text = richTextBox3.Text + "\n" + item.ModellId + ". " + item.ModellName;
            }
        }

        /// <summary>
        /// Изчистване на всички textBox и richTextBox полета в tab Models.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>v
        private void button13_Click(object sender, EventArgs e)
        {
            //Model Clear
            textBox8.Clear();
            textBox7.Clear();
            richTextBox3.Clear();
        }

        /// <summary>
        /// Добавя нов запис за клиент в базата данни.
        /// </summary>
        /// <remarks>Всички textBox полета без <c>textBox11</c> в tab Clients трябва да бъдат попълнени, за да се добави нов запис.</remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button24_Click(object sender, EventArgs e)
        {
            //Client Add
            richTextBox4.Clear();
            if (textBox11.Text != "")
            {
                string message = "Do not enter an ID! \nThe program will give each client a unique ID on its own.";
                string title = "Warning!";
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (textBox9.Text == "" || textBox13.Text == "")
                {
                    string message = "All fields are required!";
                    string title = "Warning!";
                    MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        /// <summary>
        /// Актуализира се запис на клиент в базата данни.
        /// </summary>
        /// <remarks>Трябва всички textBox полета в tab Clients да бъдат запълнени, включително и ID на клиента, който искаме да актуализираме.</remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button23_Click(object sender, EventArgs e)
        {
            //Client Update
            richTextBox4.Clear();
            if (textBox11.Text == "")
            {
                string message = "Enter client ID!";
                string title = "Warning!";
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        richTextBox4.Text = "Done!";
                    }
                    else
                    {
                        string message = "All fields required!";
                        string title = "Warning!";
                        MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    string message = "Client not found!";
                    string title = "Error!";
                    MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                textBox11.Clear();
                textBox9.Clear();
                textBox13.Clear();
            }
        }

        /// <summary>
        /// Изтрива се запис на клиент от базата данни по ID.
        /// </summary>
        /// <remarks>За изпълнението на този метод е нужно само ID на клиента(<c>ClientId</c>), който желаем да изтрием.</remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button22_Click(object sender, EventArgs e)
        {
            //Client Delete
            richTextBox4.Clear();
            if (textBox11.Text == "")
            {
                string message = "Enter client ID!";
                string title = "Warning!";
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int clientid = int.Parse(textBox11.Text);
                Client client = carhouseBusiness.GetClient(clientid);
                if (client != null)
                {
                    carhouseBusiness.DeleteClient(clientid);
                    richTextBox4.Text = "Done.";
                }
                else
                {
                    string message = "Client not found.";
                    string title = "Error!";
                    MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                textBox11.Clear();
                textBox9.Clear();
                textBox13.Clear();
            }
        }

        /// <summary>
        /// Извежда се запис на клиент от базата данни по ID.
        /// </summary>
        /// <remarks>За изпълнението на този метод е нужно само ID на клиента (<c>ClientId</c>), който желаем да изтрием.</remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button21_Click(object sender, EventArgs e)
        {
            //Client Fetch
            richTextBox4.Clear();
            if (textBox11.Text == "")
            {
                string message = "Enter client ID!";
                string title = "Warning!";
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    string message = "Client not found.";
                    string title = "Error!";
                    MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                textBox11.Clear();
                textBox9.Clear();
                textBox13.Clear();
            }
        }

        /// <summary>
        /// Извеждат се всички записи от таблица Client от базата данни.
        /// </summary>
        /// <remarks>Не е нужно да се попълва textBox поле, за да работи този метод.</remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button20_Click(object sender, EventArgs e)
        {
            //Client List All
            richTextBox4.Clear();
            var client = carhouseBusiness.GetAllClients();
            richTextBox4.Text = "All Clients" + "\n" + new string('-', 16);
            foreach (var item in client)
            {
                richTextBox4.Text = richTextBox4.Text + "\n" + item.ClientId + ". " + item.ClientName + "\nPhone: " + item.Phone + "\n";
            }
        }

        /// <summary>
        /// Изчистване на всички textBox и richTextBox полета в tab Clients.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button19_Click(object sender, EventArgs e)
        {
            //Client Clear
            richTextBox4.Clear();
            textBox11.Clear();
            textBox9.Clear();
            textBox13.Clear();
        }

        

        /// <summary>
        /// Добавя нов запис за поръчки в базата данни.
        /// </summary>
        /// <remarks>Всички textBox полета без <c>textBox16</c> в tab Orders трябва да бъдат попълнени, за да се добави нов запис.</remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button30_Click(object sender, EventArgs e)
        {
            //Order Add
            richTextBox5.Clear();
            if (textBox16.Text != "")
            {
                string message = "Do not enter an ID! \nThe program will give each order a unique ID on its own.";
                string title = "Warning!";
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (textBox15.Text == "" || textBox14.Text == "")
                {
                    string message = "All fields are required!";
                    string title = "Warning!";
                    MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        string message = "Car or client does not exist!";
                        string title = "Error!";
                        MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            textBox14.Clear();
            textBox15.Clear();
            textBox16.Clear();
        }

        /// <summary>
        /// Актуализира се запис на поръчка в базата данни.
        /// </summary>
        /// <remarks>Трябва всички textBox полета в tab Orders да бъдат запълнени, включително и ID на поръчката, която искаме да актуализираме.</remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button29_Click(object sender, EventArgs e)
        {
            //Order Update
            richTextBox5.Clear();
            if (textBox16.Text == "")
            {
                string message = "Enter order ID!";
                string title = "Warning!";
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                            richTextBox5.Text = "Done!";
                        }
                        else
                        {
                            string message = "Car or client does not exist!";
                            string title = "Error!";
                            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        string message = "All fields required!";
                        string title = "Warning!";
                        MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    string message = "Order not found!";
                    string title = "Error!";
                    MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            textBox14.Clear();
            textBox15.Clear();
            textBox16.Clear();
        }

        /// <summary>
        /// Изтрива се запис на поръчка от базата данни по ID.
        /// </summary>
        /// <remarks>За изпълнението на този метод е нужно само ID на поръчката(<c>OrderId</c>), която желаем да изтрием.</remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button28_Click(object sender, EventArgs e)
        {
            //Order Delete
            richTextBox5.Clear();
            if (textBox16.Text == "")
            {
                string message = "Enter order ID!";
                string title = "Warning!";
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int orderid = int.Parse(textBox16.Text);
                Order order = carhouseBusiness.GetOrder(orderid);
                if (order != null)
                {
                    carhouseBusiness.DeleteOrder(orderid);
                    richTextBox5.Text = "Done.";
                }
                else
                {
                    string message = "Order not found.";
                    string title = "Error!";
                    MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                textBox14.Clear();
                textBox15.Clear();
                textBox16.Clear();
            }
        }

        /// <summary>
        /// Извежда се запис на поръчка от базата данни по ID.
        /// </summary>
        /// <remarks>За изпълнението на този метод е нужно само ID на поръчката (<c>OrderId</c>), която желаем да изтрием.</remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button27_Click(object sender, EventArgs e)
        {
            //Order Fetch
            richTextBox5.Clear();
            if (textBox16.Text == "")
            {
                string message = "Enter order ID!";
                string title = "Warning!";
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    string message = "Order not found.";
                    string title = "Error!";
                    MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                textBox14.Clear();
                textBox15.Clear();
                textBox16.Clear();
            }
        }

        /// <summary>
        /// Извеждат се всички записи от таблица Order от базата данни.
        /// </summary>
        /// <remarks>Не е нужно да се попълва textBox поле, за да работи този метод.</remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button26_Click(object sender, EventArgs e)
        {
            //Order List All
            richTextBox5.Clear();
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

        /// <summary>
        /// Изчистване на всички textBox и richTextBox полета в tab Orders.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button25_Click(object sender, EventArgs e)
        {
            //Order Clear
            richTextBox5.Clear();
            textBox14.Clear();
            textBox15.Clear();
            textBox16.Clear();
        }

        /// <summary>
        /// Таймер, с който осъществяваме функцията на екрана при зареждане.
        /// </summary>
        /// <remarks>При всеки Tick, <c>progressBar1</c> се запълва, докато стигне 100. Когато го достигне - таймерът се спира, крият се <c>pictureBox1</c>, <c>pictureBox2</c>, <c>label32</c> и <c>progressBar1</c>.</remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            progressBar1.Increment(2);
            if (progressBar1.Value == 100)
            {
                timer1.Enabled = false;
                pictureBox1.Hide();
                pictureBox2.Hide();
                progressBar1.Hide();
                label32.Hide();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
