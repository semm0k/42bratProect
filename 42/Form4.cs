using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _42
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Относительные пути к фотографиям в папке Images
                string photoPath1 = Path.Combine(Application.StartupPath, "Images", "goldcol.jpg");
                string photoPath2 = Path.Combine(Application.StartupPath, "Images", "goldcol.jpg");

                if (File.Exists(photoPath1) && File.Exists(photoPath2))
                {
                    // Преобразуем фотографии в байтовые массивы
                    byte[] photo1Bytes = File.ReadAllBytes(photoPath1);
                    byte[] photo2Bytes = File.ReadAllBytes(photoPath2);

                    string checkQuery = "SELECT COUNT(*) FROM gold_jewelry WHERE ring_image_gold = @photo1 OR ring_image_gold = @photo2";

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
                                string insertQuery = "INSERT INTO gold_jewelry (catalog_id, price, ring_image_gold) VALUES (@catalog_id, @price, @ring_image_gold)";

                                using (MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection))
                                {
                                    // Пример: добавляем данные для одного товара
                                    insertCommand.Parameters.AddWithValue("@catalog_id", 1); 
                                    insertCommand.Parameters.AddWithValue("@price", 100.00m);
                                    insertCommand.Parameters.AddWithValue("@ring_image_gold", photo1Bytes);

                                    insertCommand.ExecuteNonQuery();

                                    // Повторяем для второй фотографии, если необходимо
                                    insertCommand.Parameters["@ring_image_gold"].Value = photo2Bytes;
                                    insertCommand.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }

                Form8 form8 = new Form8();
                form8.Show();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке изображений или работы с базой данных: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string photoPath1 = Path.Combine(Application.StartupPath, "Images", "goldoje.jpg");
                string photoPath2 = Path.Combine(Application.StartupPath, "Images", "goldoje.jpg");

                if (File.Exists(photoPath1) && File.Exists(photoPath2))
                {
                    byte[] photo1Bytes = File.ReadAllBytes(photoPath1);
                    byte[] photo2Bytes = File.ReadAllBytes(photoPath2);

                    string checkQuery = "SELECT COUNT(*) FROM gold_jewelry WHERE necklace_image_gold = @photo1 OR necklace_image_gold = @photo2";

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
                                string insertQuery = "INSERT INTO gold_jewelry (catalog_id, price, necklace_image_gold) VALUES (@catalog_id, @price, @necklace_image_gold)";

                                using (MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection))
                                {
                                    insertCommand.Parameters.AddWithValue("@catalog_id", 1); 
                                    insertCommand.Parameters.AddWithValue("@price", 100.00m);
                                    insertCommand.Parameters.AddWithValue("@necklace_image_gold", photo1Bytes);

                                    insertCommand.ExecuteNonQuery();

                                    insertCommand.Parameters["@necklace_image_gold"].Value = photo2Bytes;
                                    insertCommand.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }

                Form9 form9 = new Form9();
                form9.Show();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке изображений или работы с базой данных: " + ex.Message);
            }
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

            string imagePath = Path.Combine(appDirectory, "фотки100", "goldcol.jpg");

            try
            {
                if (File.Exists(imagePath))
                {
                    pictureBox2.Image = Image.FromFile(imagePath);

                    pictureBox2.Size = new Size(100, 100);

                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage; 

                    SaveImageToDatabase(imagePath);
                }
                else
                {
                    MessageBox.Show("Файл изображения не найден по пути: " + imagePath);
                }

                Form8 form8 = Application.OpenForms.OfType<Form8>().FirstOrDefault();

                if (form8 == null)
                {
                    form8 = new Form8();
                }

                form8.Show();

                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке изображения: " + ex.Message);
            }
        }


        private void SaveImageToDatabase(string imagePath)
        {
            try
            {
                string connectionString = "Server=localhost;Database=boss;User ID=root;Password=1337;";

                byte[] imageData = File.ReadAllBytes(imagePath);

                string query = "INSERT INTO gold_jewelry (ring_image_gold) VALUES (@image_data)";

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@image_data", imageData);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении изображения: " + ex.Message);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            string appDirectory = Application.StartupPath;

            string imagePath = Path.Combine(appDirectory, "фотки100", "goldoje.jpg");

            try
            {
                if (File.Exists(imagePath))
                {
                    pictureBox3.Image = Image.FromFile(imagePath);

                    pictureBox3.Size = new Size(100, 100);

                    pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage; 

                    SaveImageToDatabaseFromFile(imagePath);
                }
                else
                {
                    MessageBox.Show("Файл изображения не найден по пути: " + imagePath);
                }

                Form9 form9 = Application.OpenForms.OfType<Form9>().FirstOrDefault();

                if (form9 == null)
                {
                    form9 = new Form9();
                }

                form9.Show();

                this.Close();  

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке изображения: " + ex.Message);
            }
        }

        private void SaveImageToDatabaseFromFile(string imagePath)
        {
            try
            {
                string connectionString = "Server=localhost;Database=boss;User ID=root;Password=1337;";

                byte[] imageData = File.ReadAllBytes(imagePath);

                string query = "INSERT INTO gold_jewelry (necklace_image_gold) VALUES (@image_data)";

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@image_data", imageData);

                        cmd.ExecuteNonQuery(); 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении изображения: " + ex.Message);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            string appDirectory = Application.StartupPath;

            string imagePath = Path.Combine(appDirectory, "фотки100", "goldcep.jpg");

            try
            {
                if (File.Exists(imagePath))
                {
                    pictureBox4.Image = Image.FromFile(imagePath);

                    pictureBox4.Size = new Size(100, 100);

                    pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;

                    SaveImageToDatabaseFromGold(imagePath);
                }
                else
                {
                    MessageBox.Show("Файл изображения не найден по пути: " + imagePath);
                }

                Form10 Form10 = Application.OpenForms.OfType<Form10>().FirstOrDefault();

                if (Form10 == null)
                {
                    Form10 = new Form10();
                }

                Form10.Show();

                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке изображения: " + ex.Message);
            }
        }

        private void SaveImageToDatabaseFromGold(string imagePath)
        {
            try
            {
                string connectionString = "Server=localhost;Database=boss;User ID=root;Password=1337;";

                byte[] imageData = File.ReadAllBytes(imagePath);

                string query = "INSERT INTO gold_jewelry (chain_image_gold) VALUES (@image_data)";

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@image_data", imageData);

                        cmd.ExecuteNonQuery(); 
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
                string photoPath1 = Path.Combine(Application.StartupPath, "Images", "goldcep.jpg");
                string photoPath2 = Path.Combine(Application.StartupPath, "Images", "goldcep.jpg");

                if (File.Exists(photoPath1) && File.Exists(photoPath2))
                {
                    byte[] photo1Bytes = File.ReadAllBytes(photoPath1);
                    byte[] photo2Bytes = File.ReadAllBytes(photoPath2);

                    string checkQuery = "SELECT COUNT(*) FROM gold_jewelry WHERE necklace_image_gold = @photo1 OR necklace_image_gold = @photo2";

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
                                string insertQuery = "INSERT INTO gold_jewelry (necklace_image_gold) VALUES (@necklace_image_gold)";

                                using (MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection))
                                {
                                    // Пример: добавляем данные для одного товара
                                    insertCommand.Parameters.AddWithValue("@necklace_image_gold", photo1Bytes); 

                                    insertCommand.ExecuteNonQuery(); 

                                    insertCommand.Parameters["@necklace_image_gold"].Value = photo2Bytes;
                                    insertCommand.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }

                Form10 form10 = new Form10();
                form10.Show();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке изображений или работы с базой данных: " + ex.Message);
            }
        }
    }
}