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
using Model;

namespace WypozyczalniaElektronarzedzi
{
    /// <summary>
    /// Logika interakcji dla klasy ProduktySzukaj.xaml
    /// </summary>
    public partial class ProduktySzukaj : UserControl
    {
        public ProduktySzukaj()
        {
            InitializeComponent();

            UpdateUi();
            KategoriaCB.SelectionChanged += (sender, args) =>
            {
                if (KategoriaCB.SelectedItem != null)
                {
                    using (var context = new WypozyczalniaEntities())
                    {
                        var modele = context.Produkty
                            .Where(x => x.IDKategorii == ((Kategorie) KategoriaCB.SelectedItem).IDKategorii)
                            .Select(y => y.Model).Distinct().ToList();
                        var marki = context.Produkty
                            .Where(x => x.IDKategorii == ((Kategorie) KategoriaCB.SelectedItem).IDKategorii)
                            .Select(y => y.Marka).Distinct().ToList();
                        ModelCB.ItemsSource = modele;
                        MarkaCB.ItemsSource = marki;
                    }
                }
            };

            MarkaCB.SelectionChanged += (sender, args) =>
            {
                if (MarkaCB.SelectedItem != null)
                {
                    using (var context = new WypozyczalniaEntities())
                    {
                        if (KategoriaCB.SelectedItem != null)
                        {
                            var modele = context.Produkty
                                .Where(x => x.IDKategorii == ((Kategorie) KategoriaCB.SelectedItem).IDKategorii &&
                                            x.Marka == (string) MarkaCB.SelectedItem)
                                .Select(y => y.Model).Distinct().ToList();
                            ModelCB.ItemsSource = modele;
                        }
                    }
                }
            };
        }

        private void UpdateUi()
        {
            using (var context = new WypozyczalniaEntities())
            {
                KategoriaCB.ItemsSource = context.Kategorie.ToList();
                KategoriaCB.DisplayMemberPath = "NazwaKategorii";
                PunktCB.ItemsSource = context.PunktObslugi.ToList();
                PunktCB.DisplayMemberPath = "Miasto";
                MarkaCB.ItemsSource = context.Produkty.Select(x => x.Marka).Distinct().ToList();
                ModelCB.ItemsSource = context.Produkty.Select(x => x.Model).Distinct().ToList();
                PunktCB.SelectedItem = null;
                KategoriaCB.SelectedItem = null;
                MarkaCB.SelectedItem = null;
                ModelCB.SelectedItem = null;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new WypozyczalniaEntities())
            {
                ProduktyGrid.ItemsSource = context.Produkty.Join(context.ProduktySz,
                    produkty => produkty.IDProduktu, sz => sz.IDProduktu,
                    (produkty, sz) => new
                    {
                        ID = sz.IDProduktuSz,
                        Marka = produkty.Marka,
                        Model = produkty.Model,
                        Doba = produkty.CenaZaDobe,
                        Kaucja = produkty.Kaucja,
                        
                        Kategoria = produkty.IDKategorii,
                        PunktO = context.PunktObslugi.FirstOrDefault(x => x.IDPunktu == sz.IDPunktu).Miasto,
                        StanTechniczny = sz.StanTechniczny
                    }).Where(arg =>
                    arg.Kategoria == ((Kategorie) KategoriaCB.SelectedItem).IDKategorii &&
                    arg.Model == ModelCB.SelectedItem && arg.Marka == MarkaCB.SelectedItem).ToList();
            }
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            UpdateUi();
        }
    }
}