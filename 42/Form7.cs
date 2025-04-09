using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace _42
{
    public partial class Form7 : Form
    {
        private decimal totalPrice = 0;  
        private List<Product> cartItems = new List<Product>(); 

        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            RefreshCart();

            LoadPaymentMethods();
        }

        public void AddProductToCart(string productName, decimal productPrice)
        {
            var product = new Product { Name = productName, Price = productPrice };
            cartItems.Add(product);

            RefreshCart();
        }

        private void RefreshCart()
        {
            listBox1.Items.Clear();

            foreach (var product in cartItems)
            {
                listBox1.Items.Add($"{product.Name} - {product.Price:C}");
            }

            totalPrice = cartItems.Sum(item => item.Price);
            label4.Text = $"Total Price: {totalPrice:C}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cartItems.Clear();
            RefreshCart(); // Обновляем отображение корзины

            totalPrice = 0;
            label4.Text = $"Total Price: {totalPrice:C}";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 form1 = Application.OpenForms.OfType<Form1>().FirstOrDefault();

            if (form1 == null)
            {
                form1 = new Form1();
            }

            form1.Show();

            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedItem == null)
                {
                    MessageBox.Show("Пожалуйста, выберите способ оплаты!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                cartItems.Clear();
                totalPrice = 0;
                label4.Text = $"Total Price: {totalPrice:C}";

                MessageBox.Show("Спасибо за покупку!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await Task.Delay(2500);

                Form1 form1 = Application.OpenForms.OfType<Form1>().FirstOrDefault();

                if (form1 == null)
                {
                // Если Form1 ещё не существует, создаём новый экземпляр
                    form1 = new Form1();
                }

            // Показываем Form1
                form1.Show();

                this.Close();
            }
            catch (Exception ex)
            {
                // Если возникла ошибка, покажем сообщение об ошибке
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void LoadPaymentMethods()
        {
            string connectionString = "Server=localhost;Database=boss;User ID=root;Password=1337;";
            string query = "SELECT DISTINCT payment_method FROM payment";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            comboBox1.Items.Clear();

                    // Добавляем данные из базы в ComboBox
                            while (reader.Read())
                            {
                                string paymentMethod = reader.GetString("payment_method");
                                comboBox1.Items.Add(paymentMethod); // Добавляем метод оплаты в comboBox
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
            }
        }

        public class Product
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}