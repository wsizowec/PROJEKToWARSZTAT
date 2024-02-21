using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class Item
    {
        public int itemID { get; set; }

        private string nazwa;
        private double cena;

        public string Nazwa { get { return nazwa; } set { nazwa = value; } }

        public double Cena { get { return cena; } set { cena = value; } }


        public Item() { }

        public Item(string nazwa, double cena)
        {
            this.nazwa = nazwa;
            this.cena = cena;
        }
    }
}