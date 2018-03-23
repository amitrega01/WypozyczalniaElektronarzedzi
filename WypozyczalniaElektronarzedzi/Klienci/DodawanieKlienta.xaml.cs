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

namespace WypozyczalniaElektronarzedzi
{
    /// <summary>
    /// Logika interakcji dla klasy DodawanieKlienta.xaml
    /// </summary>
    public partial class DodawanieKlienta : UserControl
    {
        public DodawanieKlienta()
        {
            InitializeComponent();
        }

        private void DodajBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ImieTB.Text != String.Empty && NazwiskoTB.Text != String.Empty && PESELTB.Text != null)
            {
                using (var context = new WypozyczalniaEntities())
                {
                    Klienci klienci = new Klienci
                    {
                        Imie = ImieTB.Text,
                        Nazwisko = NazwiskoTB.Text,
                        PESEL = PESELTB.Text,
                        SkanDowodu = null
                    };
                    context.Klienci.Add(klienci);
                    context.SaveChanges();
                    ImieTB.Text = "";
                    NazwiskoTB.Text = "";
                    PESELTB.Text = "";
                }
            }
        }
    }
}