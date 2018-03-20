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
        }

        private void SzukajBtn_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new WypozyczalniaEntities())
            {

                //todo wyszukiwanie produktow 
            }
        }

        private void CellOnClick(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
