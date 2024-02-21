using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace WpfApp1
{
    internal class Order
    {
        private int _orderID;
        private int itemID;
        private string imie, nazwisko, pesel, date, phone, marka, model;

        public int OrderID { get { return _orderID; } set { _orderID = value; } }
        public int ItemID { get { return itemID; } set { itemID = value; } }
        public string Imie { get { return imie; } set { imie = value; } }
        public string Nazwisko { get { return nazwisko; } set { nazwisko = value; } }
        public string Pesel { get { return pesel; } set { pesel = value; } }
        public string Marka { get { return marka; } set { marka = value; } }
        public string Model { get { return model; } set { model = value; } }
        public string Date { get { return date; } set { date = value; } }
        public string Phone { get { return phone; } set { phone = value; } }


        public Order() { }

        public Order(int OrderID, int itemID, string pesel, string date, string phone, string imie, string nazwisko, string marka, string model)
        {
            this.OrderID = OrderID;
            this.ItemID = itemID;
            this.Pesel = pesel;
            this.Date = date;
            this.Phone = phone;
            this.Imie = imie;
            this.Nazwisko = nazwisko;
            this.Marka = marka;
            this.Model = model;
        }
    }
}