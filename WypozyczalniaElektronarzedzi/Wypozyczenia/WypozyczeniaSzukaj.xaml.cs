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
using UI;

namespace WypozyczalniaElektronarzedzi
{
    /// <summary>
    /// Logika interakcji dla klasy WypozyczeniaSzukaj.xaml
    /// </summary>
    public partial class WypozyczeniaSzukaj : UserControl
    {
        public WypozyczeniaSzukaj()
        {
            InitializeComponent();
            WypozyczeniaService wypozyczenia = new WypozyczeniaService();
            WypozyczeniaDG.ItemsSource = wypozyczenia.listaWypozyczen;
         
        }

    }
}
