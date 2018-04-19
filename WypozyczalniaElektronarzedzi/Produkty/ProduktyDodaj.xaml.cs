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
using ModelBazy;
using UI;

namespace WypozyczalniaElektronarzedzi
{
    /// <summary>
    /// Logika interakcji dla klasy ProduktyDodaj.xaml
    /// </summary>
    public partial class ProduktyDodaj : UserControl
    {
        private int[] stanTechniczny = {1, 2, 3, 4, 5};

        private ProduktyService produkty;
        private PunktyObslugiService punkty;
        private KategorieService kategorie;


        public ProduktyDodaj()
        {
            InitializeComponent();
            produkty = new ProduktyService();
            punkty = new PunktyObslugiService();
            kategorie = new KategorieService();
            MarkaCB.SelectionChanged += (sender, args) =>
            {
                ModelCB.ItemsSource = produkty.produktyList.Where(x => x.Marka == (MarkaCB.SelectedItem as string))
                    .Select(x => x.Model).Distinct();
            };

            UpdateUI();
        }


        private void UpdateUI()

        {
            StanTechCB.ItemsSource = stanTechniczny;
            PunktObslugiCB.ItemsSource = punkty.PunktyObslugi;
            PunktObslugiCB.DisplayMemberPath = "Miasto";
            KategoriaCB.ItemsSource = kategorie.Kategorie.Select(x => x);
            KategoriaCB.DisplayMemberPath = "Nazwa";


            MarkaCB.ItemsSource = produkty.produktyList.Select(x => x.Marka).Distinct().ToList();
            ModelCB.ItemsSource = produkty.produktyList.Select(x => x.Model).Distinct().ToList();
            StanTechCB2.ItemsSource = stanTechniczny;
            PunktObslugiCB2.ItemsSource = punkty.PunktyObslugi.ToList();


            PunktObslugiCB2.DisplayMemberPath = "Miasto";


            KategoriaCB.SelectedItem = null;
            StanTechCB.SelectedItem = null;
            StanTechCB2.SelectedItem = null;
            PunktObslugiCB.SelectedItem = null;
            PunktObslugiCB2.SelectedItem = null;
            MarkaCB.SelectedItem = null;
            ModelCB.SelectedItem = null;
            ModelTB.Text = String.Empty;
            MarkaTB.Text = String.Empty;
            CenaZaDobeTB.Text = String.Empty;
            Kaucja.Text = String.Empty;
        }

        private void DodajProduktBtn_Click(object sender, RoutedEventArgs e)
        {
            if (KategoriaCB.SelectedItem != null && MarkaTB.Text != String.Empty && ModelTB.Text != String.Empty &&
                CenaZaDobeTB.Text != String.Empty && Kaucja.Text != String.Empty && StanTechCB.SelectedItem != null &&
                PunktObslugiCB.SelectedItem != null)
            {
                Produkty entity = new Produkty
                {
                    IDProduktu = produkty.GetMax(),
                    Kategoria = ((Kategorie) KategoriaCB.SelectedItem).IDKategorii,
                    Marka = MarkaTB.Text,
                    Model = ModelTB.Text,
                    CenaZaDobe = Convert.ToDecimal(CenaZaDobeTB.Text),
                    Kaucja = Convert.ToDecimal(Kaucja.Text)
                };
                ProduktySz entity2 = new ProduktySz
                {
                    IDProduktu = entity.IDProduktu,
                    IDProduktuSZ = produkty.GetMaxSz(),
                    IDPunktuObslugi = ((PunktyObslugi) PunktObslugiCB.SelectedItem).IDPunktuObslugi,
                    Stantechniczny = ((int) StanTechCB.SelectedItem)
                };

                var tuple = new Tuple<Produkty, ProduktySz>(entity, entity2);

                produkty.AddEntity(tuple);


                UpdateUI();
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
                        IDProduktuSZ = context.ProduktySz.Select(x => x.IDProduktuSZ).Max() + 1,
                        IDProduktu = matka.IDProduktu,
                        IDPunktuObslugi = ((PunktyObslugi) PunktObslugiCB2.SelectedItem).IDPunktuObslugi,
                        Stantechniczny = ((int) StanTechCB2.SelectedItem)
                    };
                    context.ProduktySz.Add(entity);
                    context.SaveChanges();
                    UpdateUI();
                }
            }
        }
    }
}