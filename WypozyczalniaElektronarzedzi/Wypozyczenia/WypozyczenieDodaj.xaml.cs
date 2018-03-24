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
using ModelBazy;

namespace WypozyczalniaElektronarzedzi
{
    /// <summary>
    /// Logika interakcji dla klasy WypozyczenieDodaj.xaml
    /// </summary>
    public partial class WypozyczenieDodaj : UserControl
    {
        public WypozyczenieDodaj()
        {
            InitializeComponent();
            UpdateUI();
        }
        public void UpdateUI()
        {
            using (var context = new WypozyczalniaEntities())
            {
                ProduktyLB.ItemsSource = context.PelnyProdukt.ToList();
                
            }
        }
    }
}
