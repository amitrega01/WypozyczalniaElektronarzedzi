using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ModelBazy;
using UI;

namespace WypozyczalniaElektronarzedzi
{
    /// <summary>
    /// Logika interakcji dla klasy KategoriaDodaj.xaml
    /// </summary>
    public partial class KategoriaDodaj : Window
    {
        public KategoriaDodaj()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            KategorieService kat = new KategorieService();
            Kategorie entity = new Kategorie
            {
                IDKategorii = kat.GetMax(),
                Nazwa = NazwaTB.Text
            };

            kat.AddEntity(entity);
            this.Close();
        }
    }
}