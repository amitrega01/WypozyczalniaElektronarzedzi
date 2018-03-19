using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
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
                var punktyObslugi = context.PunktObslugi.Select(x => x).ToList().Select(x => x.ToString());
                PunktObslugi.ItemsSource = punktyObslugi;
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
                PunktObslugi = PunktObslugi.SelectedIndex+1
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