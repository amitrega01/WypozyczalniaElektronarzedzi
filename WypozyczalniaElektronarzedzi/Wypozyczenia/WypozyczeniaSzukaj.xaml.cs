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
using AutoMapper;
using ModelBazy;
using UI;
using WypozyczalniaElektronarzedzi.Dialog;

namespace WypozyczalniaElektronarzedzi
{
    /// <summary>
    /// Logika interakcji dla klasy WypozyczeniaSzukaj.xaml
    /// </summary>
    public partial class WypozyczeniaSzukaj : UserControl
    {
        private WypozyczeniaService wypozyczenia;
        public static WypozyczeniaSzukaj UC;
        public WypozyczeniaSzukaj()
        {
            InitializeComponent();
            UC = this;
            wypozyczenia = new WypozyczeniaService();


            DataContext = wypozyczenia.listaWypozyczen;

            WypozyczeniaDG.MouseDoubleClick += (sender, args) =>
            {
                var temp = (sender as DataGrid).SelectedItem as WypozyczenieView;
               /* wypozyczenia.Zwrocenie(
                    ((sender as DataGrid).SelectedItem as WypozyczenieView).ID, MainWindow.AppWindow.pracownik.PESEL);
                UpdateUI();*/
                Zwracanie zw   = new Zwracanie();
                zw.Koszt = temp.Cena.ToString();
                zw.Klient = temp.Klient;
                zw.produkty = wypozyczenia.GetSzczegolowe(temp.ID);
                zw.ShowDialog();

            };


            Refresh.Click += (sender, args) => { UpdateUI(); };
        }

        public void UpdateUI()
        {
            wypozyczenia.Refresh();
            DataContext = wypozyczenia.listaWypozyczen;
        }

        private void NieZwroconeChip_Click(object sender, RoutedEventArgs e)
        {
            WypozyczeniaDG.ItemsSource = wypozyczenia.listaWypozyczen.Where(x => x.DataZwrotu == null);
        }
    }
}