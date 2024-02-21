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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Button_Log_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = textBoxPass.Password.Trim();

            if (login.Length < 5)
            {
                textBoxLogin.ToolTip = "To pole jest wpisane błędnie!";
                textBoxLogin.Background = Brushes.DeepPink;

            }

            else if (pass.Length < 6)
            {
                textBoxPass.ToolTip = "To pole jest wpisane błędnie!";
                textBoxPass.Background = Brushes.DeepPink;
            }

            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;

                textBoxPass.ToolTip = "";
                textBoxPass.Background = Brushes.Transparent;

                User logUser = null;
                using (ApplicationContext db = new ApplicationContext())
                {
                    logUser = db.Users.Where(b => b.Login == login && b.Pass == pass).FirstOrDefault();
                }

                if (logUser != null)
                {
                    MessageBox.Show("Witamy!", "Info");

                    if (login == "Admin")
                    {
                        AdminPageWindow adminPageWindow = new AdminPageWindow();
                        adminPageWindow.Show();
                    }
                    else
                    {
                        UserPageWindow userPageWindow = new UserPageWindow();
                        userPageWindow.Show();
                        
                    }
                    Hide();
                }



                else
                {
                    MessageBox.Show("Cos poszlo nie tak!", "Info");
                }

            }
        }


        private void Button_Click_Glowna(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
        }

        private void Button_Click_Reg(object sender, RoutedEventArgs e)
        {
            this.Hide();
            RegWindow regwindow = new RegWindow();
            regwindow.Show();
        }

        private void Button_Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
