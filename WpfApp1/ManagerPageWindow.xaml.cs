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
    /// Логика взаимодействия для ManagerPageWindow.xaml
    /// </summary>
    public partial class ManagerPageWindow : Window
    {
        private readonly ApplicationContext db;

        public ManagerPageWindow()
        {
            InitializeComponent();
            db = new ApplicationContext();
            dataGridItems.ItemsSource = db.Items.ToList();
        }

        private void Button_Add_Items(object sender, RoutedEventArgs e)
        {
            string newItemNazwa = TextBoxNewItemNazwa.Text.Trim();
            string newItemCenaText = TextBoxNewItemCena.Text.Trim();

            if (string.IsNullOrEmpty(newItemNazwa) || string.IsNullOrEmpty(newItemCenaText) || !double.TryParse(newItemCenaText, out double newItemCena))
            {
                MessageBox.Show("Podaj prawidłową nazwę usługi.", "Info");
                return;
            }

            Item newItem = new Item
            {
                Nazwa = newItemNazwa,
                Cena = newItemCena
            };

            db.Items.Add(newItem);
            db.SaveChanges();

            dataGridItems.ItemsSource = db.Items.ToList();

            TextBoxNewItemNazwa.Clear();
            TextBoxNewItemCena.Clear();

            MessageBox.Show("Nowa usługa została dodana!", "Info");
        }

        private void Button_Update_Items(object sender, RoutedEventArgs e)
        {
            Item selectedItem = dataGridItems.SelectedItem as Item;

            if (selectedItem == null)
            {
                MessageBox.Show("Wybierz usługę do aktualizacji.", "Info");
                return;
            }

            string updatedItemNazwa = TextBoxItemNazwa.Text.Trim();
            string updatedItemCenaText = TextBoxItemCena.Text.Trim();

            if (string.IsNullOrEmpty(updatedItemNazwa) && string.IsNullOrEmpty(updatedItemCenaText))
            {
                MessageBox.Show("Podaj nową nazwę lub nową cenę wybranej usługi.", "Info");
                return;
            }

            if (!string.IsNullOrEmpty(updatedItemNazwa))
            {
                selectedItem.Nazwa = updatedItemNazwa;
            }

            if (!string.IsNullOrEmpty(updatedItemCenaText) && double.TryParse(updatedItemCenaText, out double updatedItemCena))
            {
                selectedItem.Cena = updatedItemCena;
            }

            db.SaveChanges();

            dataGridItems.ItemsSource = db.Items.ToList();

            TextBoxItemNazwa.Clear();
            TextBoxItemCena.Clear();

            MessageBox.Show("Wybrana usługa została zaktualizowana!", "Info");
        }

        private void Button_Delete_Items(object sender, RoutedEventArgs e)
        {
            Item selectedItem = dataGridItems.SelectedItem as Item;

            if (selectedItem == null)
            {
                MessageBox.Show("Wybrana usługa została zaktualizowana!", "Info");
                return;
            }

            db.Items.Remove(selectedItem);
            db.SaveChanges();

            dataGridItems.ItemsSource = db.Items.ToList();

            MessageBox.Show("Wybrana usługa została usunięta!", "Info");
        }

    }
}
