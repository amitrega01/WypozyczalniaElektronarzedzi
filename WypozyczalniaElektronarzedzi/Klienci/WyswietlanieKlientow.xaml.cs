using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ModelBazy;
using UI;

namespace WypozyczalniaElektronarzedzi
{
    public partial class WyswietlanieKlientow : UserControl
    {
        private KlienciService klienci;

        public WyswietlanieKlientow()
        {
            InitializeComponent();
            klienci = new KlienciService();
            UpdateUI();
        }

        /// <summary>
        /// Odswieża interfejs i pobiera dane z bazy na nowo
        /// </summary>
        public void UpdateUI()
        {
            KlienciGrid.ItemsSource = klienci.Klienci;
        }

        private void OdwiezBtn_Click(object sender, RoutedEventArgs e)
        {
            UpdateUI();
        }
    }
}