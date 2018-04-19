using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ModelBazy;
using UI;

namespace WypozyczalniaElektronarzedzi
{
    /// <summary>
    /// Logika interakcji dla klasy ProduktySzukaj.xaml
    /// </summary>
    public partial class ProduktySzukaj : UserControl
    {
        private ProduktyService produktyRes;

        public ProduktySzukaj()
        {
            InitializeComponent();

            
            KategoriaCB.SelectionChanged += (sender, args) => { UpdateResults(KategoriaCB); };

            MarkaCB.SelectionChanged += (sender, args) => { UpdateResults(MarkaCB); };
            ModelCB.SelectionChanged += (sender, args) => { UpdateResults(ModelCB); };
            produktyRes = new ProduktyService();
            UpdateUi();
        }

        private void UpdateResults(object sender)
        {
            if (sender == KategoriaCB)
            {
                if (KategoriaCB.SelectedItem != null)
                {
                    var modele = produktyRes.produktyList
                        .Where(x => x.Kategoria == ((Kategorie) KategoriaCB.SelectedItem).Nazwa)
                        .Select(y => y.Model).Distinct().ToList();
                    var marki = produktyRes.produktyList
                        .Where(x => x.Kategoria == ((Kategorie) KategoriaCB.SelectedItem).Nazwa)
                        .Select(y => y.Marka).Distinct().ToList();
                    ModelCB.ItemsSource = modele;
                    MarkaCB.ItemsSource = marki;
                    ProduktyGrid.ItemsSource = produktyRes.produktyList
                        .Where(arg =>
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
                        modele = produktyRes.produktyList
                            .Where(x => x.Kategoria == ((Kategorie) KategoriaCB.SelectedItem).Nazwa &&
                                        x.Marka == (string) MarkaCB.SelectedItem)
                            .Select(y => y.Model).Distinct().ToList();

                        ProduktyGrid.ItemsSource = produktyRes.produktyList
                            .Where(arg =>
                                arg.Marka == MarkaCB.SelectedItem.ToString() &&
                                arg.Kategoria == ((Kategorie) KategoriaCB.SelectedItem).Nazwa)
                            .ToList();
                    }
                    else
                    {
                        modele = produktyRes.produktyList
                            .Where(x => x.Marka == (string) MarkaCB.SelectedItem)
                            .Select(y => y.Model).Distinct().ToList();

                        ProduktyGrid.ItemsSource = produktyRes.produktyList
                            .Where(arg =>
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
                    ProduktyGrid.ItemsSource = produktyRes.produktyList
                        .Where((dto => dto.Model == ModelCB.SelectedItem.ToString()));
                }
            }
        }

        private void UpdateUi()
        {
            KategorieService kat = new KategorieService();
            PunktyObslugiService pkt = new PunktyObslugiService();


            KategoriaCB.ItemsSource = kat.Kategorie;

            PunktCB.ItemsSource = pkt.PunktyObslugi;

            MarkaCB.ItemsSource = produktyRes.produktyList.Select(x => x.Marka).Distinct().ToList();
            ModelCB.ItemsSource = produktyRes.produktyList.Select(x => x.Model).Distinct().ToList();


            KategoriaCB.DisplayMemberPath = "Nazwa";
            PunktCB.DisplayMemberPath = "Miasto";

            PunktCB.SelectedItem = null;
            KategoriaCB.SelectedItem = null;
            MarkaCB.SelectedItem = null;
            ModelCB.SelectedItem = null;
            produktyRes = new ProduktyService();
            ProduktyGrid.ItemsSource = produktyRes.produktyList;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            UpdateUi();
        }
    }
}