using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ModelBazy;

namespace WypozyczalniaElektronarzedzi
{
    /// <summary>
    /// Logika interakcji dla klasy ProduktySzukaj.xaml
    /// </summary>
    public partial class ProduktySzukaj : UserControl
    {
        private List<PelnyProdukt> produktyRes;

        public ProduktySzukaj()
        {
            InitializeComponent();

            UpdateUi();
            KategoriaCB.SelectionChanged += (sender, args) => { UpdateResults(KategoriaCB); };

            MarkaCB.SelectionChanged += (sender, args) => { UpdateResults(MarkaCB); };
            ModelCB.SelectionChanged += (sender, args) => { UpdateResults(ModelCB); };
        }

        private void UpdateResults(object sender)
        {
            if (sender == KategoriaCB)
            {
                if (KategoriaCB.SelectedItem != null)
                {
                    var modele = produktyRes
                        .Where(x => x.Kategoria == ((Kategorie) KategoriaCB.SelectedItem).Nazwa)
                        .Select(y => y.Model).Distinct().ToList();
                    var marki = produktyRes
                        .Where(x => x.Kategoria == ((Kategorie) KategoriaCB.SelectedItem).Nazwa)
                        .Select(y => y.Marka).Distinct().ToList();
                    ModelCB.ItemsSource = modele;
                    MarkaCB.ItemsSource = marki;
                    ProduktyGrid.ItemsSource = produktyRes.Where(arg =>
                            arg.Kategoria == ((Kategorie) KategoriaCB.SelectedItem).Nazwa)
                        .ToList();

                    ModelCB.SelectedItem = null;
                    MarkaCB.SelectedItem = null;
                }
            }
            else if (sender == MarkaCB)
            {
                if (MarkaCB.SelectedItem != null)
                {
                    List<String> modele;
                    if (KategoriaCB.SelectedItem != null)
                    {
                        modele = produktyRes
                            .Where(x => x.Kategoria == ((Kategorie) KategoriaCB.SelectedItem).Nazwa &&
                                        x.Marka == (string) MarkaCB.SelectedItem)
                            .Select(y => y.Model).Distinct().ToList();

                        ProduktyGrid.ItemsSource = produktyRes.Where(arg =>
                                arg.Marka == MarkaCB.SelectedItem.ToString() &&
                                arg.Kategoria == ((Kategorie) KategoriaCB.SelectedItem).Nazwa)
                            .ToList();
                    }
                    else
                    {
                        modele = produktyRes
                            .Where(x => x.Marka == (string) MarkaCB.SelectedItem)
                            .Select(y => y.Model).Distinct().ToList();

                        ProduktyGrid.ItemsSource = produktyRes.Where(arg =>
                                arg.Marka == MarkaCB.SelectedItem.ToString())
                            .ToList();
                    }

                    ModelCB.ItemsSource = modele;
                }
            }
            else if (sender == ModelCB)
            {
                if (ModelCB.SelectedItem != null)
                {
                    ProduktyGrid.ItemsSource = produktyRes.Where((dto => dto.Model == ModelCB
                                                                             .SelectedItem.ToString()));
                }
            }
        }

        private void UpdateUi()
        {
            using (var context = new WypozyczalniaEntities())
            {
                KategoriaCB.ItemsSource = context.Kategorie.ToList();
                KategoriaCB.DisplayMemberPath = "Nazwa";
                PunktCB.ItemsSource = context.PunktyObslugi.ToList();
                PunktCB.DisplayMemberPath = "Miasto";
                MarkaCB.ItemsSource = context.Produkty.Select(x => x.Marka).Distinct().ToList();
                ModelCB.ItemsSource = context.Produkty.Select(x => x.Model).Distinct().ToList();
                PunktCB.SelectedItem = null;
                KategoriaCB.SelectedItem = null;
                MarkaCB.SelectedItem = null;
                ModelCB.SelectedItem = null;
                produktyRes = context.PelnyProdukt.ToList();
                ProduktyGrid.ItemsSource = produktyRes;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /*
                        using (var context = new WypozyczalniaEntities())
                        {
                            ProduktyGrid.ItemsSource = context.Produkty.Join(context.ProduktySz,
                                produkty => produkty.IDProduktu, sz => sz.IDProduktu,
                                (produkty, sz) => new ProduktyDto
                                {
                                    ID = sz.IDProduktuSz,
                                    Marka = produkty.Marka,
                                    Model = produkty.Model,
                                    Doba = produkty.CenaZaDobe,
                                    Kaucja = produkty.Kaucja,
            
                                    IDKategorii = produkty.IDKategorii,
                                    PunktO = context.PunktObslugi.FirstOrDefault(x => x.IDPunktu == sz.IDPunktu).Miasto,
                                    StanTechniczny = sz.StanTechniczny
                                }).Where(arg =>
                                arg.IDKategorii == ((Kategorie) KategoriaCB.SelectedItem).IDKategorii &&
                                arg.Model == ModelCB.SelectedItem && arg.Marka == MarkaCB.SelectedItem).ToList();
                        }*/
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            UpdateUi();
        }
    }
}