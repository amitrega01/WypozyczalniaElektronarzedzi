using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using ModelBazy;
using UI;

namespace WypozyczalniaElektronarzedzi
{
    /// <summary>
    /// Logika interakcji dla klasy DodawanieKlienta.xaml
    /// </summary>
    public partial class DodawanieKlienta : UserControl
    {
        private KlienciService klienciS;

        public DodawanieKlienta()
        {
            InitializeComponent();
            klienciS = new KlienciService();
        }

        private void DodajBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ImieTB.Text != String.Empty && NazwiskoTB.Text != String.Empty && PESELTB.Text != null)
            {
                Klienci klienci = new Klienci
                {
                    Imie = ImieTB.Text,
                    Nazwisko = NazwiskoTB.Text,
                    PESEL = PESELTB.Text,
                    SkanDowodu = null
                };
                klienciS.AddEntity(klienci);
                ImieTB.Text = "";
                NazwiskoTB.Text = "";
                PESELTB.Text = "";
            }
        }
    }
}