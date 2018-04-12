using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ModelBazy;
namespace WypozyczalniaElektronarzedzi
{   
    public partial class WyswietlanieKlientow : UserControl
    {   
        List<Klienci> klienciRes;
        public WyswietlanieKlientow()
        {
            InitializeComponent();
            klienciRes = new List<Klienci>();
            UpdateUI();
        }
        /// <summary>
        /// Odswieża interfejs i pobiera dane z bazy na nowo
        /// </summary>
        public void UpdateUI()
        {
            using (var context = new WypozyczalniaEntities()) 
            {
                klienciRes = context.Klienci.ToList();
            }

          
            KlienciGrid.ItemsSource = klienciRes;
        }

        private void OdwiezBtn_Click(object sender, RoutedEventArgs e)
        {
            UpdateUI();
        }
    }
}
