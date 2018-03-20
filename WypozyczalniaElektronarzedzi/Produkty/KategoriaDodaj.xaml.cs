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
using System.Windows.Shapes;
using Model;

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
            using (var context = new WypozyczalniaEntities())
            {
                int a = 0;
                try
                {
                    a = context.Kategorie.Select(x => x.IDKategorii).Max();
                    a++;
                }
                catch (Exception exception)
                {
                    a = 1;
                }

                Kategorie entity = new Kategorie
                {
                    IDKategorii = a,
                    NazwaKategorii = NazwaTB.Text
                };
                context.Kategorie.Add(entity);
                context.SaveChanges();
                this.Close();
            }
        }
    }
}