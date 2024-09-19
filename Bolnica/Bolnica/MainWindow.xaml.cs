using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bolnica
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string connectionString = "Server=.\\SQLEXPRESS;Database=DSA;Trusted_Connection=True;";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string enteredPhoneNumber = Login.Text;
            string enteredPassword = Password.Password;

            
            if (string.IsNullOrWhiteSpace(enteredPhoneNumber) || string.IsNullOrWhiteSpace(enteredPassword))
            {
                MessageBox.Show("Please enter both email and password.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string sqlQuery = "SELECT Password FROM [User] WHERE Email = @Email";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Email", enteredPhoneNumber);

                        string passwordFromDB = (string)command.ExecuteScalar();

                        if (passwordFromDB != null && passwordFromDB.Equals(enteredPassword))
                        {
                            MainMenu mainWindow = new MainMenu();
                            this.Close();
                            mainWindow.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Неверная почта или пароль");
                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show($"Ошибка базы данных: {sqlEx.Message}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}");
                }
            }

        }

        private void Login_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}