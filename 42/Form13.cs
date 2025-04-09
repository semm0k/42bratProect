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
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 form1 = Application.OpenForms.OfType<Form1>().FirstOrDefault();

            if (form1 == null)
            {
                form1 = new Form1();
            }

            form1.Show();

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form7 form7 = Application.OpenForms.OfType<Form7>().FirstOrDefault();

            if (form7 == null)
            {
                form7 = new Form7(); // Убираем передачу ссылки на текущую форму
            }

            string productName = label1.Text; // Название товара из label1
            decimal productPrice = decimal.Parse(label3.Text); // Цена товара из label3

            form7.AddProductToCart(productName, productPrice);

            form7.Show();

            this.Close();
        }
    }
}