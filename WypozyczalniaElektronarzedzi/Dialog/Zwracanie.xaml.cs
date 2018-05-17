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
using ModelBazy;

namespace WypozyczalniaElektronarzedzi.Dialog
{
    /// <summary>
    /// Logika interakcji dla klasy Zwracanie.xaml
    /// </summary>
    public partial class Zwracanie : Window
    {
        public string Koszt { get; set; }
        public List<Produkty> produkty { get; set; }
        public string Klient { get; set; }

        public Zwracanie()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
