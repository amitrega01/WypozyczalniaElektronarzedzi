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
    /// <summary>
    /// Logika interakcji dla klasy WypozyczenieDodaj.xaml
    /// </summary>
    public partial class WypozyczenieDodaj : UserControl
    {
        private ObservableCollection<PelnyProdukt> produktyPodsum;
        private ObservableCollection<PelnyProdukt> wszystkie;
        private Decimal suma = 0;

        //todo dodawanie wypozyczenia, wybieranie produktow itp przeniesc dodawanie wypozyczenia do nowego okna!!!!


        public WypozyczenieDodaj()
        {
            InitializeComponent();
            UpdateUI();

            ProduktyLB.MouseDoubleClick += (sender, args) =>
            {
              
                produktyPodsum.Add(ProduktyLB.SelectedItem as PelnyProdukt);
                wszystkie.Remove(ProduktyLB.SelectedItem as PelnyProdukt);
    
            };
        }

        public void UpdateUI()
        {
            produktyPodsum = new ObservableCollection<PelnyProdukt>();
            PodsumowanieProdukty.ItemsSource = produktyPodsum;
            using (var context = new WypozyczalniaEntities())
            {
                ProduktyLB.ItemsSource = wszystkie = new ObservableCollection<PelnyProdukt>(
                    context.PelnyProdukt.ToList());
            }
        }
    }
}