using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
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

namespace MainSystem.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        string plainTextPasword;

        public LoginView()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            string username = txtUsername.Text;


            if (!string.IsNullOrEmpty(visibleTxtPass.Text))
            {
                txtPass.Password = visibleTxtPass.Text;
            }
            
            

            string password = txtPass.Password;

            try
            {
                Control ctrl = new Control();

                string answer = ctrl.ctrlLogin(username, password);

                if (answer.Length > 0)
                {
                    MessageBox.Show(answer, "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
            }



        }

        private void toogleVisibility_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPass.Password))
            {
                if (txtPass.PasswordChar == '●')
                {
                    txtPass.PasswordChar = '\0';
                    eyeOpenImage.Visibility = Visibility.Collapsed;
                    eyeClosedImage.Visibility = Visibility.Visible;

                    visibleTxtPass.Text = txtPass.Password.ToString();
                    visibleTxtPass.Visibility = Visibility.Visible;
                    txtPass.Visibility = Visibility.Collapsed;
                    
                }
                else
                {
                    txtPass.Password = visibleTxtPass.Text;
                    txtPass.PasswordChar = '●';
                    eyeClosedImage.Visibility = Visibility.Collapsed;
                    eyeOpenImage.Visibility = Visibility.Visible;

                    visibleTxtPass.Visibility = Visibility.Collapsed;
                    txtPass.Visibility = Visibility.Visible;
                }
            }
        }
    }
}
