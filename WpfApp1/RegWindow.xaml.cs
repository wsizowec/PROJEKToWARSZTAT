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
    /// Логика взаимодействия для RegWindow.xaml
    /// </summary>
    public partial class RegWindow : Window
    {
        ApplicationContext db;
        public RegWindow()
        {
            InitializeComponent();

            db = new ApplicationContext();
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = textBoxPass.Password.Trim();
         //   string pass_2 = textBoxPass_2.Password.Trim();
            string email = textBoxEmail.Text.Trim().ToLower();

            if(login.Length < 5)
            {
                textBoxLogin.ToolTip = "To pole jest wpisane błędnie!";
                textBoxLogin.Background = Brushes.DeepPink;

            }

            else if(pass.Length < 6) 
            {
                textBoxPass.ToolTip = "To pole jest wpisane błędnie!";
                textBoxPass.Background = Brushes.DeepPink;
            }

           /* else if (pass != pass_2)
            {
                textBoxPass_2.ToolTip = "To pole jest wpisane błędnie!";
                textBoxPass_2.Background = Brushes.DeepPink;
            }*/

            else if (email.Length < 7 || !email.Contains("@") || !email.Contains("."))
            {
                textBoxEmail.ToolTip = "To pole jest wpisane błędnie!";
                textBoxEmail.Background = Brushes.DeepPink;
            }

            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;

                textBoxPass.ToolTip = "";
                textBoxPass.Background = Brushes.Transparent;

               // textBoxPass_2.ToolTip = "";
               //textBoxPass_2.Background = Brushes.Transparent;

                textBoxEmail.ToolTip = "";
                textBoxEmail.Background = Brushes.Transparent;

                MessageBox.Show("Gratulujemy z udanej rejestracji!", "Info");
                
                User user = new User(login, email, pass);

                db.Users.Add(user);
                db.SaveChanges();

                LoginWindow loginwindow = new LoginWindow();
                loginwindow.Show();
                Hide();
            }

        }

        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Log_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            LoginWindow loginwindow = new LoginWindow();
            loginwindow.Show();
        }

        private void Button_Main_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
        }
    }
}
