using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _42
{
    public partial class Form16 : Form
    {
        public Form16()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Проверяем, если Form1 уже существует
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

        private void button1_Click(object sender, EventArgs e)
        {
            // Проверяем, если Form7 уже существует
            Form7 form7 = Application.OpenForms.OfType<Form7>().FirstOrDefault();

            if (form7 == null)
            {
                // Если Form7 ещё не существует, создаём новый экземпляр
                form7 = new Form7(); // Убираем передачу ссылки на текущую форму
            }

            // Получаем название и цену товара
            string productName = label1.Text; // Название товара из label1
            decimal productPrice = decimal.Parse(label3.Text); // Цена товара из label3

            // Передаем данные в Form7
            form7.AddProductToCart(productName, productPrice);

            // Показываем Form7
            form7.Show();

            this.Close();
        }
    }
}
