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
    /// Logika interakcji dla klasy LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        public LogIn()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Funkcja logujaca do bazy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogIn_Click(object sender, RoutedEventArgs e)
        {

            if (PeselText.Text != String.Empty && PasswordText.Password != String.Empty)
            {
                using (var context = new WypozyczalniaEntities())
                {
                    try
                    {
                        var res = context.Pracownicy.Single<Pracownicy>(x => x.PESEL.ToString() == PeselText.Text && x.Haslo == PasswordText.Password);
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.pracownik = res;
                        mainWindow.Show();
                        mainWindow.UpdateUI();
                        this.Close();

                    }
                    catch (Exception s)
                    {
                        Console.WriteLine(s);
                    }




                }

            }
        }
    }
}
