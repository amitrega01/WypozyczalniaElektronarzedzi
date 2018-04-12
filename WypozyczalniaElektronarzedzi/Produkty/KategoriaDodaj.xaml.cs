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
using ModelBazy;

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
                
                Kategorie entity = new Kategorie
                {
                    IDKategorii = context.Kategorie.Select(x=>x.IDKategorii).Max() +1,
                    Nazwa = NazwaTB.Text
                };
                context.Kategorie.Add(entity);
                context.SaveChanges();
                this.Close();
            }
        }
    }
}