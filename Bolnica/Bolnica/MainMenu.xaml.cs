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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Bolnica
{
    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    /// 
    public partial class MainMenu : Window
    {
        public static class Global2
        {
            public static string FN { get; set; }

        }

        string connectionString = "Server=.\\SQLEXPRESS;Database=DSA;Trusted_Connection=True;";
        public MainMenu()
        {
            InitializeComponent();
        }

        private void Name_TXB_Initialized(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlExpression1 = $"SELECT FirstName, LastName FROM [Staff] ";
                using (SqlCommand command = new SqlCommand(sqlExpression1, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Name_TXB.Text = reader.GetString(0);


                            Name_TXB.Text += "" + reader.GetString(1);

                            Global2.FN =Name_TXB.Text.ToString();
                        }
                    }
                }
            }
        }

        private void Post(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlExpression1 = $"SELECT Post FROM [Staff] ";
                using (SqlCommand command = new SqlCommand(sqlExpression1, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Post_TXB.Text = reader.GetString(0);
                            Global2.FN =Post_TXB.Text.ToString();
                        }
                    }
                }
            }
        }

      

        private void ZapicPacienta_Button(object sender, RoutedEventArgs e)
        {
            ZapicPacient MainMenu = new ZapicPacient();
            this.Close();
            MainMenu.ShowDialog();
        }

        private void _Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
