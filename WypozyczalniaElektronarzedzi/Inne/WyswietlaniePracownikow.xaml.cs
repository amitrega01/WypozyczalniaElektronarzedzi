using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using AutoMapper;
using ModelBazy;
using WypozyczalniaElektronarzedzi.UI;

namespace WypozyczalniaElektronarzedzi
{
    /// <summary>
    /// Logika interakcji dla klasy WyswietlaniePracownikow.xaml
    /// </summary>
    public partial class WyswietlaniePracownikow : UserControl
    {
        public static UserControl UserControlWP;

        public WyswietlaniePracownikow()
        {
            InitializeComponent();
            UserControlWP = this;
            Mapper.Initialize(cfg => { cfg.CreateMap<Pracownicy, PracownicyDto>(); });
            UpdateUI();
            PracownicyGrid.AutoGenerateColumns = true;
            this.Width = PracownicyGrid.RowHeaderActualWidth;
        }   

        private void CellOnClick(object sender, MouseButtonEventArgs e)
        {
            DataGridCell cell = sender as DataGridCell;
            var res = cell.DataContext as PracownicyDto;
            MessageBox.Show(res.Nazwisko);
        }

        public void UpdateUI()
        {
            using (var context = new WypozyczalniaEntities())
            {
                var temp = context.Pracownicy.Join(context.PunktyObslugi, pracownicy => pracownicy.IDPunktuObslugi,
                    obslugi => obslugi.IDPunktuObslugi, (pracownicy, obslugi) => new
                    {
                        Pesel = pracownicy.PESEL,
                        Imie = pracownicy.Imie,
                        Nazwisko = pracownicy.Nazwisko,
                        PunktObslugiPracownika = obslugi.Ulica+" "+ obslugi.NrDomu + ", " + obslugi.Miasto
                    }).ToList();
                PracownicyGrid.ItemsSource = temp;
            }
        }
    }
}