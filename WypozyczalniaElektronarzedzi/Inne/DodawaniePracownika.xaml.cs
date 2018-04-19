using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ModelBazy;
using UI;
using WypozyczalniaElektronarzedzi;

namespace WypozyczalniaElektronarzedzi
{
    /// <summary>
    /// Logika interakcji dla klasy DodawaniePracownika.xaml
    /// </summary>
    public partial class DodawaniePracownika : UserControl
    {
        public DodawaniePracownika()
        {
            InitializeComponent();
            PunktyObslugiService pkt = new PunktyObslugiService();
            PunktObslugi.ItemsSource = pkt.PunktyObslugi;
            PunktObslugi.DisplayMemberPath = "Miasto";
        }


        private void CreatePracownikBtn_Click(object sender, RoutedEventArgs e)
        {
            Pracownicy pracownik = new Pracownicy
            {
                Imie = ImieTextBox.Text,
                Nazwisko = NazwiskoTextBox.Text,
                PESEL = PESELTextBox.Text,
                Haslo = HasloTextBox.Text,
                IDPunktuObslugi = (PunktObslugi.SelectedItem as PunktyObslugi).IDPunktuObslugi,
                DataZatrudnienia = DateTime.Now
            };

            using (var prac = new PracownicyService())
            {
                prac.AddEntity(pracownik);
            }

            MainWindow.AppWindow.WyswietlaniePracownikowUC.UpdateUI();
            ImieTextBox.Text = String.Empty;
            NazwiskoTextBox.Text = String.Empty;
            PESELTextBox.Text = String.Empty;
            HasloTextBox.Text = String.Empty;
        }
    }
}