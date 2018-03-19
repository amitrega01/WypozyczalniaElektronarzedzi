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
using AutoMapper;
using Model;

namespace WypozyczalniaElektronarzedzi.UI
{
    /// <summary>
    /// Logika interakcji dla klasy WyswietlaniePracownikow.xaml
    /// </summary>
    public partial class WyswietlaniePracownikow : UserControl
    {
        public WyswietlaniePracownikow()
        {
            InitializeComponent();
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Pracownicy,PracownicyDto >();
            });

            this.Width = PracownicyGrid.RowHeaderActualWidth;
            using (var context = new WypozyczalniaEntities())
            {
                var temp = context.Pracownicy.AsParallel().Select(x=> Mapper.Map<PracownicyDto>(x));
                PracownicyGrid.AutoGenerateColumns = true;

                PracownicyGrid.ItemsSource = temp;

            }
            
        }

        private void CellOnClick(object sender, MouseButtonEventArgs e)
        {
            DataGridCell cell = sender as DataGridCell;
            var res = cell.DataContext as PracownicyDto;
            MessageBox.Show(res.Nazwisko);
        }


     
    }
}
