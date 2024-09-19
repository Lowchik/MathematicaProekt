using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Bolnica
{
    /// <summary>
    /// Логика взаимодействия для ZapicPacient.xaml
    /// </summary>
    public partial class ZapicPacient : Window
    {
        string connectionString = "Server=.\\SQLEXPRESS;Database=DSA;Trusted_Connection=True;";
        public ZapicPacient()
        {
            InitializeComponent();
        }
        bool check = false;
        public class Pacient
        {
            public string FistName { get; set; }
            public string LastName { get; set; }
            public DateTime Birthday { get; set; }
            public int Snils { get; set; }
            public DateTime Date { get; set; }
            public TimeSpan Time { get; set; }
            public string Doctor { get; set; }
           
        }
        private void CheckSpicok()
        {
            List<Pacient> equipmentList = new List<Pacient>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sqlQuery = "SELECT FistName, Pacient.LastName, Birthday, Snils, date, time, Doctor FROM Pacient ";
                   
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Pacient cr = new Pacient();

                            cr.FistName = reader.GetString(0);
                            cr.LastName = reader.GetString(1);
                            cr.Birthday = reader.GetDateTime(2);
                            cr.Snils = reader.GetInt32(3);
                            cr.Date = reader.GetDateTime(4);
                            cr.Time = reader.GetTimeSpan(5);
                            cr.Doctor = reader.GetString(6);


                            equipmentList.Add(cr);
                        }
                    }
                }
            }
            CheckindDataGrid.ItemsSource = equipmentList;
        }

        private void ZapicPacienta()
        {
            string sqlQueryy = "INSERT INTO Pacient (Pacient_ID, FistName, LastName, Birthday, Snils, date, time, Doctor) VALUES ((SELECT ISNULL(MAX(Pacient_ID), 0) + 1 FROM Pacient), @FirstName, @LastName, @Birthday, @Snils, @date, @time, @Doctor)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlQueryy, connection);

                    if (NameTextBox.Text == "" && !check)
                    {
                        MessageBox.Show("Поле Имя не должно быть пустое");
                        check = true;
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@FirstName", NameTextBox.Text);
                    }
                    if (FamiliyaTextBox.Text == "" && !check)
                    {
                        MessageBox.Show("Пол Фамилия не должно быть пустое");
                        check = true;
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@LastName", FamiliyaTextBox.Text);
                    }
                    if (BirthdayTextBox.Text == "" && !check)
                    {
                        MessageBox.Show("Поле дата рождения  не должно быть пустое");
                        check = true;
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@Birthday", BirthdayTextBox.Text);
                    }

                    if (SnilsTextBox.Text == "" && !check)
                    {
                        MessageBox.Show("Поле Снилс  не должно быть пустое");
                        check = true;
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@Snils", SnilsTextBox.Text);
                    }

                    if (DateTextBox.Text == "" && !check)
                    {
                        MessageBox.Show("Поле Дата записи  не должно быть пустое");
                        check = true;
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@date", DateTextBox.Text);
                    }
                    if (TimeTextBox.Text == "" && !check)
                    {
                        MessageBox.Show("Поле Время  не должно быть пустое");
                        check = true;
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@time", TimeTextBox.Text);
                    }
                    if (DoctorTextBox.Text == "" && !check)
                    {
                        MessageBox.Show("Поле Время  не должно быть пустое");
                        check = true;
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@Doctor", DoctorTextBox.Text);
                    }



                    int number = command.ExecuteNonQuery();
                    MessageBox.Show($"Добавлено объектов: {number}");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Ошибка при изменении данных: " + ex.Message);
                }
            }
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ZapicButton_Click(object sender, RoutedEventArgs e)
        {
            ZapicPacienta();
        }

        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
           
            if (CheckindDataGrid.Visibility == System.Windows.Visibility.Visible)
            {
               
                CheckindDataGrid.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                
                CheckSpicok();
                CheckindDataGrid.Visibility = System.Windows.Visibility.Visible;
            }

        }
    }
}
