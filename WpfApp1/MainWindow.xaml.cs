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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Button_Click_Login(object sender, RoutedEventArgs e)
        {
            this.Hide();
            LoginWindow loginwindow = new LoginWindow();
            loginwindow.Show();
        }

        private void Button_Click_Reg(object sender, RoutedEventArgs e)
        {
            this.Hide();
            RegWindow regwindow = new RegWindow();
            regwindow.Show();
        }

        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
