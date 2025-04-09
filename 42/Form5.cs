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

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string appDirectory = Application.StartupPath;

            string imagePath = Path.Combine(appDirectory, "фотки100", "silvercol.jpg");

            try
            {
                if (File.Exists(imagePath))
                {
                    pictureBox2.Image = Image.FromFile(imagePath);

                    pictureBox2.Size = new Size(100, 100);

                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage; // Растягиваем изображение

                    SaveImageToDatabaseFromSilver(imagePath);
                }
                else
                {
                    MessageBox.Show("Файл изображения не найден по пути: " + imagePath);
                }

                Form11 Form11 = Application.OpenForms.OfType<Form11>().FirstOrDefault();

                if (Form11 == null)
                {
                    Form11 = new Form11();
                }

                Form11.Show();

                this.Close();  // Закрывает текущую форму

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке изображения: " + ex.Message);
            }
        }

        private void SaveImageToDatabaseFromSilver(string imagePath)
        {
            try
            {
                string connectionString = "Server=localhost;Database=boss;User ID=root;Password=1337;";

                byte[] imageData = File.ReadAllBytes(imagePath);

                string query = "INSERT INTO silver_jewelry (ring_image_silver) VALUES (@image_data)";

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
                string photoPath1 = Path.Combine(Application.StartupPath, "Images", "silvercol.jpg");
                string photoPath2 = Path.Combine(Application.StartupPath, "Images", "silvercol.jpg");

                if (File.Exists(photoPath1) && File.Exists(photoPath2))
                {
                    byte[] photo1Bytes = File.ReadAllBytes(photoPath1);
                    byte[] photo2Bytes = File.ReadAllBytes(photoPath2);

                    string checkQuery = "SELECT COUNT(*) FROM silver_jewelry WHERE ring_image_silver = @photo1 OR ring_image_silver = @photo2";

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
                                string insertQuery = "INSERT INTO silver_jewelry (ring_image_silver) VALUES (@ring_image_silver)";

                                using (MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection))
                                {
                                    insertCommand.Parameters.AddWithValue("@ring_image_silver", photo1Bytes); // Загрузка первой фотографии

                                    insertCommand.ExecuteNonQuery(); // Выполняем вставку первой фотографии

                                    insertCommand.Parameters["@ring_image_silver"].Value = photo2Bytes;
                                    insertCommand.ExecuteNonQuery(); // Выполняем вставку второй фотографии
                                }
                            }
                        }
                    }
                }

                Form11 Form11 = new Form11();
                Form11.Show();

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

            string imagePath = Path.Combine(appDirectory, "фотки100", "silveroje.jpg");

            try
            {
                if (File.Exists(imagePath))
                {
                    pictureBox3.Image = Image.FromFile(imagePath);

                    pictureBox3.Size = new Size(100, 100);

                    pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage; // Растягиваем изображение

                    SaveImageToDatabaseFromSSilver(imagePath);
                }
                else
                {
                    MessageBox.Show("Файл изображения не найден по пути: " + imagePath);
                }

                Form12 Form12 = Application.OpenForms.OfType<Form12>().FirstOrDefault();

                if (Form12 == null)
                {
                    Form12 = new Form12();
                }

                Form12.Show();

                this.Close();  // Закрывает текущую форму

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке изображения: " + ex.Message);
            }
        }

        private void SaveImageToDatabaseFromSSilver(string imagePath)
        {
            try
            {
                string connectionString = "Server=localhost;Database=boss;User ID=root;Password=1337;";

                byte[] imageData = File.ReadAllBytes(imagePath);

                string query = "INSERT INTO silver_jewelry (necklace_image_silver) VALUES (@image_data)";

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
                string photoPath1 = Path.Combine(Application.StartupPath, "Images", "silvercol.jpg");
                string photoPath2 = Path.Combine(Application.StartupPath, "Images", "silvercol.jpg");

                if (File.Exists(photoPath1) && File.Exists(photoPath2))
                {
                    byte[] photo1Bytes = File.ReadAllBytes(photoPath1);
                    byte[] photo2Bytes = File.ReadAllBytes(photoPath2);

                    string checkQuery = "SELECT COUNT(*) FROM silver_jewelry WHERE necklace_image_silver = @photo1 OR necklace_image_silver = @photo2";

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
                                string insertQuery = "INSERT INTO silver_jewelry (necklace_image_silver) VALUES (@necklace_image_silver)";

                                using (MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection))
                                {
                                    insertCommand.Parameters.AddWithValue("@necklace_image_silver", photo1Bytes); // Загрузка первой фотографии

                                    insertCommand.ExecuteNonQuery(); // Выполняем вставку первой фотографии

                                    insertCommand.Parameters["@necklace_image_silver"].Value = photo2Bytes;
                                    insertCommand.ExecuteNonQuery(); // Выполняем вставку второй фотографии
                                }
                            }
                        }
                    }
                }

                Form12 Form12 = new Form12();
                Form12.Show();

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

            string imagePath = Path.Combine(appDirectory, "фотки100", "silvercep.jpg");

            try
            {
                if (File.Exists(imagePath))
                {
                    pictureBox4.Image = Image.FromFile(imagePath);

                    pictureBox4.Size = new Size(100, 100);

                    pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage; // Растягиваем изображение

                    SaveImageToDatabaseFromSSSilver(imagePath);
                }
                else
                {
                    MessageBox.Show("Файл изображения не найден по пути: " + imagePath);
                }

                Form13 Form13 = Application.OpenForms.OfType<Form13>().FirstOrDefault();

                if (Form13 == null)
                {
                    Form13 = new Form13();
                }

                Form13.Show();

                this.Close();  // Закрывает текущую форму

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке изображения: " + ex.Message);
            }
        }

        private void SaveImageToDatabaseFromSSSilver(string imagePath)
        {
            try
            {
                string connectionString = "Server=localhost;Database=boss;User ID=root;Password=1337;";

                byte[] imageData = File.ReadAllBytes(imagePath);

                string query = "INSERT INTO silver_jewelry (chain_image_silver) VALUES (@image_data)";

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
                string photoPath1 = Path.Combine(Application.StartupPath, "Images", "silvercep.jpg");
                string photoPath2 = Path.Combine(Application.StartupPath, "Images", "silvercep.jpg");

                if (File.Exists(photoPath1) && File.Exists(photoPath2))
                {
                    byte[] photo1Bytes = File.ReadAllBytes(photoPath1);
                    byte[] photo2Bytes = File.ReadAllBytes(photoPath2);

                    string checkQuery = "SELECT COUNT(*) FROM silver_jewelry WHERE chain_image_silver = @photo1 OR chain_image_silver = @photo2";

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
                                string insertQuery = "INSERT INTO silver_jewelry (chain_image_silver) VALUES (@chain_image_silver)";

                                using (MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection))
                                {
                                    insertCommand.Parameters.AddWithValue("@chain_image_silver", photo1Bytes); // Загрузка первой фотографии

                                    insertCommand.ExecuteNonQuery(); // Выполняем вставку первой фотографии

                                    insertCommand.Parameters["@chain_image_silver"].Value = photo2Bytes;
                                    insertCommand.ExecuteNonQuery(); // Выполняем вставку второй фотографии
                                }
                            }
                        }
                    }
                }

                Form13 Form13 = new Form13();
                Form13.Show();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке изображений или работы с базой данных: " + ex.Message);
            }
        }
    }
}