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
    /// Логика взаимодействия для AdminPageWindow.xaml
    /// </summary>
    public partial class AdminPageWindow : Window
    {
        private ApplicationContext db;

        public AdminPageWindow()
        {
            InitializeComponent();
            db = new ApplicationContext();

            LoadOrders();
        }

        private void LoadOrders()
        {
            var orders = db.Orders.ToList();
           // dataGridOrders.Items.Clear();
            dataGridOrders.ItemsSource = orders;
        }

        private void Button_Uslugi(object sender, RoutedEventArgs e)
        {
            ManagerPageWindow managerPageWindow = new ManagerPageWindow();
            managerPageWindow.Show();
        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            // Получаем выбранный заказ из DataGrid
            var selectedOrder = dataGridOrders.SelectedItem as Order;

            // Проверяем, что заказ был выбран
            if (selectedOrder != null)
            {
                db.Orders.Remove(selectedOrder);
                db.SaveChanges();

                LoadOrders();
            }
            else
            {
                MessageBox.Show("Wybierz zamówienie do usunięcia.", "Info");
            }
        }


    }
}
