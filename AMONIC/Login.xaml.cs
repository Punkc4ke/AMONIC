using System;
using System.Collections.Generic;
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
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Threading;

namespace AMONIC
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        class ConnectString
        {
            public string connectionString = ConfigurationManager.ConnectionStrings["AMONIC.Properties.Settings.AMONICConnectionString"].ConnectionString;
        }

        ConnectString cs = new ConnectString();

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (Username.Text.Trim() != "" && Password.Password.Trim() != "")
            {
                using (SqlConnection connection = new SqlConnection(cs.connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand($"SELECT * FROM [dbo].[Users] WHERE Email = '{Username.Text}' AND Password = '{Password.Password}'", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader["RoleID"] = 1)
                        {
                            AMONIC_Airlines_Automation_system window = new AMONIC_Airlines_Automation_system();
                            window.Show();
                            this.Hide();
                        }                     
                    }
                }
            }
            else MessageBox.Show("Ошибка. Пустые поля!");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
