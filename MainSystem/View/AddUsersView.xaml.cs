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

namespace MainSystem.View
{
    /// <summary>
    /// Interaction logic for AddUsersView.xaml
    /// </summary>
    public partial class AddUsersView : Window
    {


        public AddUsersView()
        {
                
             InitializeComponent();
            
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            Usuarios usuario = new Usuarios();
            

            usuario.Name = txtUsername.Text;
            usuario.UserName = txtBelonging.Text;
            usuario.Password = txtPass.Password;
            usuario.ConPassword = txtConPass.Password;

            usuario.Id_type = cbElection.SelectedIndex + 1;


            try
            {
                Control control = new Control();
                string answer = control.ctrlRecord(usuario);

                if (answer.Length > 0)
                {
                    MessageBox.Show(answer, "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("El usuario ha sido registrado correctamente", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
