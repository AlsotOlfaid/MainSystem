using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MainSystem.View
{
    /// <summary>
    /// Interaction logic for UserView.xaml
    /// </summary>
    public partial class UserView : Page
    {
        private AddUsersView addUserInstance;

        public UserView()
        {
            InitializeComponent();
            loadUsers();

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (addUserInstance == null)
            {
                addUserInstance = new AddUsersView();
                addUserInstance.Show();

            }
            else
            {
                if (addUserInstance.WindowState == WindowState.Minimized)
                {
                    addUserInstance.WindowState = WindowState.Normal;
                }

                addUserInstance.Activate();
            }

        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = (MainWindow)this.Parent;
            main.WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = (MainWindow)this.Parent;
            main.Close();
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = (MainWindow)this.Parent;

            if (main.WindowState == WindowState.Normal)
            {
                main.WindowState = WindowState.Maximized;
            }
            else
            {
                main.WindowState = WindowState.Normal;
            }
        }

        private void loadUsers()
        {
            MySqlDataReader reader;

            MySqlConnection connection = Connection.getConnection();
            connection.Open();

            string sql = "SELECT id, name, user_name, id_type FROM usuarios";

            MySqlCommand command = new MySqlCommand(sql, connection);

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable usersTable = new DataTable();

            adapter.Fill(usersTable);

            usersDataGrid.ItemsSource = usersTable.DefaultView;

            connection.Close();
        }

        private void txtSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox != null)
            {
                textBox.Text = "";
            }
        }

        private void txtSearch_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox != null)
            {
                if (textBox.Text.Trim() == "")
                {
                    textBox.Text = "Buscar";
                }
            }
        }
    }
}
