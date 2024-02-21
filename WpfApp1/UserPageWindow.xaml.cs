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
    /// Логика взаимодействия для UserPageWindow.xaml
    /// </summary>
    public partial class UserPageWindow : Window
    {
        private ApplicationContext db;

        public UserPageWindow()
        {
            InitializeComponent();
            db = new ApplicationContext();
            var itemNames = db.Items.Select(f => f.Nazwa).ToList();
            ComboBoxUslugi.ItemsSource = itemNames;
        }

        private void Button_Umowic_Click(object sender, RoutedEventArgs e)
        {
            string selectedItem = ComboBoxUslugi.SelectedItem as string;
            DateTime Data = TextBoxData.SelectedDate ?? DateTime.Now;
            string PESEL = TextBoxPESEL.Text.Trim();
            string imie = TextBoxImie.Text.Trim();
            string nazwisko = TextBoxNazwisko.Text.Trim();
            string phoneNumber = TextBoxPhoneNumber.Text.Trim();
            string marka = TextBoxMarka.Text.Trim();
            string model = TextBoxModel.Text.Trim();

            if (string.IsNullOrEmpty(selectedItem) || Data <= DateTime.Now ||  string.IsNullOrEmpty(PESEL) || string.IsNullOrEmpty(imie) || string.IsNullOrEmpty(nazwisko) || string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(marka) || string.IsNullOrEmpty(model))
            {
                MessageBox.Show("Proszę poprawnie wypełnić wszystkie pola!", "Info");
                return;
            }

            Item item = db.Items.FirstOrDefault(f => f.Nazwa == selectedItem);
            if (item == null)
            {
                MessageBox.Show("Wybranej uslugi nie znaleziono w bazie danych!", "Info");
                return;
            }

            Order order = new Order()
            {
                ItemID = item.itemID,
                Date = Data.ToString("yyyy-MM-dd"),
                Pesel = PESEL,
                Imie = imie,
                Nazwisko = nazwisko,
                Phone = phoneNumber,
                Marka = marka,
                Model = model
            };

            db.Orders.Add(order);
            db.SaveChanges();

            MessageBox.Show("Zamówienie zostało złożone!", "Info");
            ClearForm();
        }

        private User GetLoggedInUser(string login)
        {
            return db.Users.FirstOrDefault(u => u.Login == login);
        }

        private void ClearForm()
        {
            ComboBoxUslugi.SelectedIndex = -1;
            TextBoxData.SelectedDate = DateTime.Now;
            TextBoxImie.Clear();
            TextBoxNazwisko.Clear();
            TextBoxPESEL.Clear();
            TextBoxPhoneNumber.Clear();
            TextBoxMarka.Clear();
            TextBoxModel.Clear();
        }

        private void ComboBoxUslugi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItemNazwa = ComboBoxUslugi.SelectedItem as string;
            var selectedItem = db.Items.FirstOrDefault(item => item.Nazwa == selectedItemNazwa);
            if (selectedItem != null)
            {
                totalCostTextBlock.Text = $"Kwota do zapłaty: {selectedItem.Cena} PLN";
            }
            else
            {
                totalCostTextBlock.Text = "Kwota do zapłaty: - PLN";
            }
        }


        private void textBoxLastName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
