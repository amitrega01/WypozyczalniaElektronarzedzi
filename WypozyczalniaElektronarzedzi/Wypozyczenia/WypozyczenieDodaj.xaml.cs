using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using ModelBazy;
using UI;

namespace WypozyczalniaElektronarzedzi
{
    /// <summary>
    /// Logika interakcji dla klasy WypozyczenieDodaj.xaml
    /// </summary>
    /// 
    /// 
    /// 
    public partial class WypozyczenieDodaj : UserControl
    {
        private ObservableCollection<PelnyProdukt> produktyPodsum;
        private List<PelnyProdukt> wszystkie;
        private Decimal suma = 0;

        private WypozyczenieEnitity temp;
        //todo dodawanie wypozyczenia, wybieranie produktow itp przeniesc dodawanie wypozyczenia do nowego okna!!!!


        public WypozyczenieDodaj()
        {
            InitializeComponent();
            temp = new WypozyczenieEnitity();
            DataContext = temp;
            UpdateUI();
            ProduktySzukaj.ProduktyGrid.IsReadOnly = true;
            ProduktySzukaj.ProduktyGrid.MouseDoubleClick += (sender, args) =>
            {
                PelnyProdukt t = (sender as DataGrid).SelectedItem as PelnyProdukt;
                if (!temp.produkty.Contains(t))
                {
                    temp.produkty.Add(t);
                    UpdateCeny();
                }
            };

            KlienciSzukaj.KlienciGrid.IsReadOnly = true;
            KlienciSzukaj.KlienciGrid.MouseDoubleClick += (sender, args) =>
            {
                Klienci k = (sender as DataGrid).SelectedItem as Klienci;
                temp.klient = k;
                KlientInfoUC.DataContext = temp.klient;
            };

            DatePickerW.SelectedDateChanged += (sender, args) =>
            {
                temp.dataDoZwrotu = (DateTime) DatePickerW.SelectedDate;
            };
            PodsumowanieProdukty.SelectedCellsChanged += (sender, args) => 
            {
                UpdateCeny();
            }
            ;
            PodsumowanieProdukty.MouseDoubleClick += (sender, args) =>
                {
                    temp.produkty.Remove((sender as DataGrid).SelectedItem as PelnyProdukt);
                    UpdateCeny();
                };

        }

        private void UpdateCeny()
        {

            temp.UpdateCeny();
            ZaDzien.Content = "Za dzień: " + temp.zaDzien;
            Kaucja.Content = "Kaucja: " + temp.kaucja;
        }

        public void UpdateUI()
        {
            produktyPodsum = new ObservableCollection<PelnyProdukt>();
        }

        private void DodajWypozyczeniClick(object sender, RoutedEventArgs e)
        {

            temp.IDPrac = MainWindow.AppWindow.pracownik.PESEL;
            WypozyczeniaService service = new WypozyczeniaService();
            service.AddEntity(temp);
            WypozyczeniaSzukaj.UC.UpdateUI();
        }
    }
}