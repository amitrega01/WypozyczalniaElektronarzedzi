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
using Model;

namespace WypozyczalniaElektronarzedzi.UI
{
    /// <summary>
    /// Logika interakcji dla klasy DodawaniePracownika.xaml
    /// </summary>
    public partial class DodawaniePracownika : UserControl
    {
        public DodawaniePracownika()
        {
            InitializeComponent();
            using (var context = new WypozyczalniaEntities())
            {
                var punktyObslugi = context.PunktObslugi.Select(x =>(int) x.IDPunktu);
                PunktObslugi.ItemsSource = punktyObslugi.ToList<int>();
            }
        }

        private void CreatePracownikBtn_Click(object sender, RoutedEventArgs e)
        {
            Pracownicy pracownik = new Pracownicy
            {
                Imie = ImieTextBox.Text,
                Nazwisko = NazwiskoTextBox.Text,
                PESEL = Convert.ToDecimal(PESELTextBox.Text),
                Haslo = HasloTextBox.Text,
                PunktObslugi = (int) PunktObslugi.SelectedItem 
            };
            using (var context = new WypozyczalniaEntities())
            {
                context.Pracownicy.Add(pracownik);
                context.SaveChanges();
            }
            ImieTextBox.Text = String.Empty;
            NazwiskoTextBox.Text = String.Empty;
            PESELTextBox.Text = String.Empty;
            HasloTextBox.Text = String.Empty;
        }
    }
}
