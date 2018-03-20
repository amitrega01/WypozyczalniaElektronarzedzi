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
        private int[] stanTechniczny = {1, 2, 3, 4, 5};

        public ProduktyDodaj()
        {
            InitializeComponent();


            UpdateUI();
        }


        private void UpdateUI()

        {
            KategoriaCB.ItemsSource = null;

            using (var context = new WypozyczalniaEntities())
            {
                StanTechCB.ItemsSource = stanTechniczny;
                PunktObslugiCB.ItemsSource = context.PunktObslugi.ToList();
                PunktObslugiCB.DisplayMemberPath = "Miasto";
                KategoriaCB.ItemsSource = context.Kategorie.Select(x => x).ToList();
                KategoriaCB.DisplayMemberPath = "NazwaKategorii";


                MarkaCB.ItemsSource = context.Produkty.Select(x => x.Marka).Distinct().ToList();
                ModelCB.ItemsSource = context.Produkty.Select(x => x.Model).Distinct().ToList();
                StanTechCB2.ItemsSource = stanTechniczny;
                PunktObslugiCB2.ItemsSource = context.PunktObslugi.ToList();


                PunktObslugiCB2.DisplayMemberPath = "Miasto";

                // KategoriaCB.Items.Add(b);
            }

            MarkaCB.SelectionChanged += (sender, args) =>
            {
                using (var context = new WypozyczalniaEntities())
                {
                    ModelCB.ItemsSource = context.Produkty.Where(x => x.Marka == MarkaCB.SelectedItem)
                        .Select(y => y.Model)
                        .Distinct().ToList();
                }
            };
        }

        private void DodajProduktBtn_Click(object sender, RoutedEventArgs e)
        {
            if (KategoriaCB.SelectedItem != null && MarkaTB.Text != String.Empty && ModelTB.Text != String.Empty &&
                CenaZaDobeTB.Text != String.Empty && Kaucja.Text != String.Empty && StanTechCB.SelectedItem != null &&
                PunktObslugiCB.SelectedItem != null)
            {
                using (var context = new WypozyczalniaEntities())
                {
                    Produkty entity = new Produkty
                    {
                        IDProduktu = context.Produkty.Select(x => x.IDProduktu).Max() + 1,
                        IDKategorii = ((Kategorie) KategoriaCB.SelectedItem).IDKategorii,
                        Marka = MarkaTB.Text,
                        Model = ModelTB.Text,
                        CenaZaDobe = Convert.ToDecimal(CenaZaDobeTB.Text),
                        Kaucja = Convert.ToDecimal(Kaucja.Text)
                    };
                    context.Produkty.Add(entity);
                    ProduktySz entity2 = new ProduktySz
                    {
                        IDProduktu = entity.IDProduktu,
                        IDProduktuSz = context.ProduktySz.Select(x => x.IDProduktuSz).Max() + 1,
                        IDPunktu = ((PunktObslugi) PunktObslugiCB.SelectedItem).IDPunktu,
                        StanTechniczny = ((int) StanTechCB.SelectedItem)
                    };
                    context.ProduktySz.Add(entity2);

                    context.SaveChanges();
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            KategoriaDodaj kategoriaDodaj = new KategoriaDodaj();
            kategoriaDodaj.Show();
            kategoriaDodaj.Closed += (o, args) => { UpdateUI(); };
        }

        private void DodajEgzBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ModelCB.SelectedItem != null && MarkaCB.SelectedItem != null && StanTechCB2.SelectedItem != null &&
                PunktObslugiCB2.SelectedItem != null)
            {
                using (var context = new WypozyczalniaEntities())
                {
                    var matka = context.Produkty.FirstOrDefault(x =>
                        x.Marka == MarkaCB.SelectedItem && x.Model == ModelCB.SelectedItem);
                    ProduktySz entity = new ProduktySz
                    {
                        IDProduktuSz = context.ProduktySz.Select(x=>x.IDProduktuSz).Max()+1,
                        IDProduktu = matka.IDProduktu,
                        IDPunktu = ((PunktObslugi) PunktObslugiCB2.SelectedItem).IDPunktu,
                        StanTechniczny = ((int) StanTechCB2.SelectedItem)
                    };
                    context.ProduktySz.Add(entity);
                    context.SaveChanges();
                }
            }
        }
    }
}