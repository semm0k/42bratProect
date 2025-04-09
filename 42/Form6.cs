using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _42
{
    public partial class Form6 : Form
    {
        public Form6()
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string appDirectory = Application.StartupPath;

            string imagePath = Path.Combine(appDirectory, "фотки100", "bijCOL.jpg");

            try
            {
                if (File.Exists(imagePath))
                {
                    pictureBox2.Image = Image.FromFile(imagePath);

                    pictureBox2.Size = new Size(100, 100);

                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage; // Растягиваем изображение

                    SaveImageToDatabaseFromBijouterie(imagePath);
                }
                else
                {
                    MessageBox.Show("Файл изображения не найден по пути: " + imagePath);
                }

                Form14 Form14 = Application.OpenForms.OfType<Form14>().FirstOrDefault();

                if (Form14 == null)
                {
                    Form14 = new Form14();
                }

                Form14.Show();

                this.Close();  // Закрывает текущую форму

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке изображения: " + ex.Message);
            }
        }

        private void SaveImageToDatabaseFromBijouterie(string imagePath)
        {
            try
            {
                string connectionString = "Server=localhost;Database=boss;User ID=root;Password=1337;";

                byte[] imageData = File.ReadAllBytes(imagePath);

                string query = "INSERT INTO bijouterie (ring_image_bijouterie) VALUES (@image_data)";

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@image_data", imageData);

                        cmd.ExecuteNonQuery(); // Не показываем результат выполнения
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении изображения: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string photoPath1 = Path.Combine(Application.StartupPath, "Images", "bijCOL.jpg");
                string photoPath2 = Path.Combine(Application.StartupPath, "Images", "bijCOL.jpg");

                if (File.Exists(photoPath1) && File.Exists(photoPath2))
                {
                    byte[] photo1Bytes = File.ReadAllBytes(photoPath1);
                    byte[] photo2Bytes = File.ReadAllBytes(photoPath2);

                    string checkQuery = "SELECT COUNT(*) FROM bijouterie WHERE ring_image_bijouterie = @photo1 OR ring_image_bijouterie = @photo2";

                    using (MySqlConnection connection = new MySqlConnection("Server=localhost;Database=boss;User ID=root;Password=1337;"))
                    {
                        connection.Open();
                        using (MySqlCommand command = new MySqlCommand(checkQuery, connection))
                        {
                            command.Parameters.AddWithValue("@photo1", photo1Bytes);
                            command.Parameters.AddWithValue("@photo2", photo2Bytes);

                            int count = Convert.ToInt32(command.ExecuteScalar());

                            if (count == 0)
                            {
                                string insertQuery = "INSERT INTO bijouterie (ring_image_bijouterie) VALUES (@ring_image_bijouterie)";

                                using (MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection))
                                {
                                    insertCommand.Parameters.AddWithValue("@ring_image_bijouterie", photo1Bytes); // Загрузка первой фотографии

                                    insertCommand.ExecuteNonQuery(); // Выполняем вставку первой фотографии

                                    insertCommand.Parameters["@ring_image_bijouterie"].Value = photo2Bytes;
                                    insertCommand.ExecuteNonQuery(); // Выполняем вставку второй фотографии
                                }
                            }
                        }
                    }
                }

                Form14 Form14 = new Form14();
                Form14.Show();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке изображений или работы с базой данных: " + ex.Message);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            string appDirectory = Application.StartupPath;

            string imagePath = Path.Combine(appDirectory, "фотки100", "bijOJE.jpg");

            try
            {
                if (File.Exists(imagePath))
                {
                    pictureBox3.Image = Image.FromFile(imagePath);

                    pictureBox3.Size = new Size(100, 100);

                    pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage; // Растягиваем изображение

                    SaveImageToDatabaseFromBBijouterie(imagePath);
                }
                else
                {
                    MessageBox.Show("Файл изображения не найден по пути: " + imagePath);
                }

                Form15 Form15 = Application.OpenForms.OfType<Form15>().FirstOrDefault();

                if (Form15 == null)
                {
                    Form15 = new Form15();
                }

                Form15.Show();

                this.Close();  // Закрывает текущую форму

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке изображения: " + ex.Message);
            }
        }

        private void SaveImageToDatabaseFromBBijouterie(string imagePath)
        {
            try
            {
                string connectionString = "Server=localhost;Database=boss;User ID=root;Password=1337;";

                byte[] imageData = File.ReadAllBytes(imagePath);

                string query = "INSERT INTO bijouterie (necklace_image_bijouterie) VALUES (@image_data)";

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@image_data", imageData);

                        cmd.ExecuteNonQuery(); // Не показываем результат выполнения
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении изображения: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string photoPath1 = Path.Combine(Application.StartupPath, "Images", "bijOJE.jpg");
                string photoPath2 = Path.Combine(Application.StartupPath, "Images", "bijOJE.jpg");

                if (File.Exists(photoPath1) && File.Exists(photoPath2))
                {
                    byte[] photo1Bytes = File.ReadAllBytes(photoPath1);
                    byte[] photo2Bytes = File.ReadAllBytes(photoPath2);

                    string checkQuery = "SELECT COUNT(*) FROM bijouterie WHERE necklace_image_bijouterie = @photo1 OR necklace_image_bijouterie = @photo2";

                    using (MySqlConnection connection = new MySqlConnection("Server=localhost;Database=boss;User ID=root;Password=1337;"))
                    {
                        connection.Open();
                        using (MySqlCommand command = new MySqlCommand(checkQuery, connection))
                        {
                            command.Parameters.AddWithValue("@photo1", photo1Bytes);
                            command.Parameters.AddWithValue("@photo2", photo2Bytes);

                            int count = Convert.ToInt32(command.ExecuteScalar());

                            if (count == 0)
                            {
                                string insertQuery = "INSERT INTO bijouterie (necklace_image_bijouterie) VALUES (@necklace_image_bijouterie)";

                                using (MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection))
                                {
                                    insertCommand.Parameters.AddWithValue("@necklace_image_bijouterie", photo1Bytes); // Загрузка первой фотографии

                                    insertCommand.ExecuteNonQuery(); // Выполняем вставку первой фотографии

                                    insertCommand.Parameters["@necklace_image_bijouterie"].Value = photo2Bytes;
                                    insertCommand.ExecuteNonQuery(); // Выполняем вставку второй фотографии
                                }
                            }
                        }
                    }
                }

                Form15 Form15 = new Form15();
                Form15.Show();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке изображений или работы с базой данных: " + ex.Message);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            string appDirectory = Application.StartupPath;

            string imagePath = Path.Combine(appDirectory, "фотки100", "bijCEP.jpg");

            try
            {
                if (File.Exists(imagePath))
                {
                    pictureBox3.Image = Image.FromFile(imagePath);

                    pictureBox3.Size = new Size(100, 100);

                    pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage; // Растягиваем изображение

                    SaveImageToDatabaseFromBBBijouterie(imagePath);
                }
                else
                {
                    MessageBox.Show("Файл изображения не найден по пути: " + imagePath);
                }

                Form16 Form16 = Application.OpenForms.OfType<Form16>().FirstOrDefault();

                if (Form16 == null)
                {
                    Form16 = new Form16();
                }

                Form16.Show();

                this.Close();  // Закрывает текущую форму

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке изображения: " + ex.Message);
            }
        }

        private void SaveImageToDatabaseFromBBBijouterie(string imagePath)
        {
            try
            {
                string connectionString = "Server=localhost;Database=boss;User ID=root;Password=1337;";

                byte[] imageData = File.ReadAllBytes(imagePath);

                string query = "INSERT INTO bijouterie (chain_image_bijouterie) VALUES (@image_data)";

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@image_data", imageData);

                        cmd.ExecuteNonQuery(); // Не показываем результат выполнения
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении изображения: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string photoPath1 = Path.Combine(Application.StartupPath, "Images", "bijCEP.jpg");
                string photoPath2 = Path.Combine(Application.StartupPath, "Images", "bijCEP.jpg");

                if (File.Exists(photoPath1) && File.Exists(photoPath2))
                {
                    byte[] photo1Bytes = File.ReadAllBytes(photoPath1);
                    byte[] photo2Bytes = File.ReadAllBytes(photoPath2);

                    string checkQuery = "SELECT COUNT(*) FROM bijouterie WHERE chain_image_bijouterie = @photo1 OR chain_image_bijouterie = @photo2";

                    using (MySqlConnection connection = new MySqlConnection("Server=localhost;Database=boss;User ID=root;Password=1337;"))
                    {
                        connection.Open();
                        using (MySqlCommand command = new MySqlCommand(checkQuery, connection))
                        {
                            command.Parameters.AddWithValue("@photo1", photo1Bytes);
                            command.Parameters.AddWithValue("@photo2", photo2Bytes);

                            int count = Convert.ToInt32(command.ExecuteScalar());

                            if (count == 0)
                            {
                                string insertQuery = "INSERT INTO bijouterie (chain_image_bijouterie) VALUES (@chain_image_bijouterie)";

                                using (MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection))
                                {
                                    insertCommand.Parameters.AddWithValue("@chain_image_bijouterie", photo1Bytes); // Загрузка первой фотографии

                                    insertCommand.ExecuteNonQuery(); // Выполняем вставку первой фотографии

                                    insertCommand.Parameters["@chain_image_bijouterie"].Value = photo2Bytes;
                                    insertCommand.ExecuteNonQuery(); // Выполняем вставку второй фотографии
                                }
                            }
                        }
                    }
                }

                Form16 Form16 = new Form16();
                Form16.Show();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке изображений или работы с базой данных: " + ex.Message);
            }
        }
    }
}