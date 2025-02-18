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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();

            form5.Show();

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Создаем экземпляр Form4
            Form4 form4 = new Form4();

            // Показываем Form4
            form4.Show();

            // Закрываем текущую форму (Form2)
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();

            form6.Show();

            this.Close();
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
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Проверяем, если Form1 уже существует
            Form7 form7 = Application.OpenForms.OfType<Form7>().FirstOrDefault();

            if (form7 == null)
            {
                // Если Form1 ещё не существует, создаём новый экземпляр
                form7 = new Form7();
            }

            // Показываем Form1
            form7.Show();

            this.Close();
        }
    }
}
