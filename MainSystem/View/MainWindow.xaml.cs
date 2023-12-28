using MainSystem.View;
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
using System.Windows.Navigation;


namespace MainSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }


        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void btnUsers_Click(object sender, RoutedEventArgs e)
        {
            if (Session.id_type == 1)
            {
                this.Content = new UserView();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
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

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
            }
            else
            {
                WindowState = WindowState.Normal;
            }
            

            
        }
    }
}
