using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace _42
{
    public partial class Form3 : Form
    {
        // Конструктор формы
        public Form3()
        {
            InitializeComponent();
        }

        // Обработчик нажатия на кнопку входа
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;  // Предполагается, что есть текстовое поле txtEmail
            string password = txtPassword.Text;  // Предполагается, что есть текстовое поле txtPassword

            // Проверка на валидность ввода
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "Пожалуйста, заполните все поля.";  // Предполагается, что есть метка lblMessage
                return;
            }

            // Проверка формата email
            if (!email.EndsWith("@gmail.com") && !email.EndsWith("@yandex.ru"))
            {
                lblMessage.Text = "Неправильный формат email.";
                return;
            }

            // Строка подключения к MySQL
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnectionString"].ConnectionString;

            // Проверка наличия пользователя в базе данных
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Измените на правильное имя столбца пароля (например, user_password)
                    string query = "SELECT * FROM Client WHERE Email = @Email AND password = @Password";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password);

                        MySqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            // Если пользователь найден, кешируем данные
                            reader.Read();  // Чтение первой строки результата

                            string cachedData = $"Email: {reader["Email"]}, Password: {reader["password"]}";
                            CacheUserData(cachedData);

                            lblMessage.Text = "Вход успешен!";
                        }
                        else
                        {
                            lblMessage.Text = "Неправильный email или пароль.";
                        }

                        reader.Close();
                    }

                    // Очистка полей ввода после успешной регистрации
                    txtEmail.Clear();  // Очищаем текстовое поле для email
                    txtPassword.Clear();  // Очищаем текстовое поле для пароля
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = $"Ошибка при проверке данных: {ex.Message}";
            }
        }

        // Обработчик нажатия на кнопку регистрации
        private void btnRegister_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;  // Предполагается, что есть текстовое поле txtEmail
            string password = txtPassword.Text;  // Предполагается, что есть текстовое поле txtPassword

            // Проверка на валидность ввода
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "Пожалуйста, заполните все поля.";  // Предполагается, что есть метка lblMessage
                return;
            }

            // Проверка формата email
            if (!email.EndsWith("@gmail.com") && !email.EndsWith("@yandex.ru"))
            {
                lblMessage.Text = "Неправильный формат email.";
                return;
            }

            // Строка подключения к MySQL
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnectionString"].ConnectionString;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Проверяем, существует ли уже пользователь с таким email
                    string checkQuery = "SELECT COUNT(*) FROM Client WHERE Email = @Email";
                    using (MySqlCommand cmd = new MySqlCommand(checkQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count > 0)
                        {
                            lblMessage.Text = "Этот email уже зарегистрирован.";
                            return;
                        }
                    }

                    // Если email не занят, добавляем нового пользователя
                    string insertQuery = "INSERT INTO Client (Email, password) VALUES (@Email, @Password)";
                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            lblMessage.Text = "Регистрация прошла успешно!";
                        }
                        else
                        {
                            lblMessage.Text = "Ошибка при регистрации.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = $"Ошибка при регистрации: {ex.Message}";
            }

            // Очистка полей ввода после попытки регистрации
            txtEmail.Clear();
            txtPassword.Clear();
        }

        // Метод для кеширования данных в текстовый файл
        private void CacheUserData(string userData)
        {
            string cacheFilePath = "user_data_cache.txt";

            try
            {
                // Сохраняем данные в файл
                File.WriteAllText(cacheFilePath, userData);
            }
            catch (Exception ex)
            {
                lblMessage.Text = $"Ошибка при сохранении данных в файл: {ex.Message}";
            }
        }

        // Другие методы для обработки событий (если нужно)
        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void Form3_Load(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Закрытие текущей формы (Form3)
            this.Close();
        }

        private void lblMessage_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
