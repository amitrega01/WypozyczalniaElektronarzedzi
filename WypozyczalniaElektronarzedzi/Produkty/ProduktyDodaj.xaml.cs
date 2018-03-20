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
using MaterialDesignThemes.Wpf;
using Model;

namespace WypozyczalniaElektronarzedzi
{
    /// <summary>
    /// Logika interakcji dla klasy ProduktyDodaj.xaml
    /// </summary>
    public partial class ProduktyDodaj : UserControl
    {
        public ProduktyDodaj()
        {
            InitializeComponent();

            UpdateUI();
        }

        private void MyBtn_Click(object sender, RoutedEventArgs e)
        {
            KategoriaDodaj kategoriaDodaj = new KategoriaDodaj();
            kategoriaDodaj.Show();
            kategoriaDodaj.Closed += (o, args) => { UpdateUI(); };
        }

        private void UpdateUI()

        {
            KategoriaCB.Items.Clear();
            Button b = new Button();
            b.Content = "Dodaj nowa kategorie...";
            b.Click += new RoutedEventHandler(MyBtn_Click);
            KategoriaCB.Items.Add(b);
            using (var context = new WypozyczalniaEntities())
            {
                foreach (var kat in context.Kategorie.OrderBy(x => x.NazwaKategorii).ToList())
                {
                    KategoriaCB.Items.Add(kat.NazwaKategorii);
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}