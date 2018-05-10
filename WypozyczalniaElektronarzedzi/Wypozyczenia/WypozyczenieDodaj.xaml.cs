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

namespace WypozyczalniaElektronarzedzi
{
    class WypozyczenieEnitity
    {
        public Wypozyczenie _wypozyczenie { get; set; }
        public ObservableCollection<PelnyProdukt> produkty { get; set; }
        public ObservableCollection<Klienci> klien { get; set; }
        public decimal zaDzien { get; set; }
        public decimal kaucja { get; set; }
        public string text { get; set; } = "Asdasd";

        public WypozyczenieEnitity()
        {
            _wypozyczenie = new Wypozyczenie();
            produkty = new ObservableCollection<PelnyProdukt>();
            klien = new ObservableCollection<Klienci>();
        }

        public void UpdateCeny()
        {
            zaDzien = 0;
            kaucja = 0;
            foreach (var p in produkty)
            {
                zaDzien += p.CenaZaDobe;
                kaucja += p.Kaucja;
            }
        }
    }

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

        //todo dodawanie wypozyczenia, wybieranie produktow itp przeniesc dodawanie wypozyczenia do nowego okna!!!!


        public WypozyczenieDodaj()
        {
            InitializeComponent();
            WypozyczenieEnitity temp = new WypozyczenieEnitity();
            DataContext = temp;
            UpdateUI();
            ProduktySzukaj.ProduktyGrid.IsReadOnly = true;
            ProduktySzukaj.ProduktyGrid.MouseDoubleClick += (sender, args) =>
            {
                PelnyProdukt t = (sender as DataGrid).SelectedItem as PelnyProdukt;
                if (!temp.produkty.Contains(t))
                {
                    temp.produkty.Add(t);
                    temp.UpdateCeny();
                    ZaDzien.Content = "Za dzień: " +  temp.zaDzien;
                    Kaucja.Content = "Kaucja: " + temp.kaucja;
                }
            };

            KlienciSzukaj.KlienciGrid.IsReadOnly = true;
            KlienciSzukaj.KlienciGrid.MouseDoubleClick += (sender, args) =>
            {
                Klienci k = (sender as DataGrid).SelectedItem as Klienci;
                temp.klien.Clear();
                temp.klien.Add(k);
            };
        }

        public void UpdateUI()
        {
            produktyPodsum = new ObservableCollection<PelnyProdukt>();
           
        }
    }
}