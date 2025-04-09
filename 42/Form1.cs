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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Создаем экземпляр второй формы (Form2)
            Form3 form3 = new Form3();

            // Открываем Form2
            form3.Show();  // Если хотите, чтобы форма открылась как модальная, используйте form2.ShowDialog()
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();

            // Показываем Form2
            form2.Show();

            // Получаем ссылку на Form1 и закрываем её
            Form1 form1 = Application.OpenForms.OfType<Form1>().FirstOrDefault();
            if (form1 != null)
            {
                form1.Hide(); // Прячем Form1 вместо её закрытия
            }
        }

        private void button2_Click(object sender, EventArgs e)
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
    }
}