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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
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

        private void button5_Click(object sender, EventArgs e)
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
