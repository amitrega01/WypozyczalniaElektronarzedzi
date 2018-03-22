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
using ModelBazy;
using WypozyczalniaElektronarzedzi.UI;

namespace WypozyczalniaElektronarzedzi
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Pracownik obsługujący program
        /// </summary>
        public Pracownicy pracownik { get; set; }

        public static MainWindow AppWindow;
        public MainWindow()
        {
            InitializeComponent();
            AppWindow = this;
        }

        private void LogInBtn_Click(object sender, RoutedEventArgs e)
        {
            if (pracownik == null)
            {

                LogIn logIn = new LogIn();
                logIn.Show();
                this.Close();
            }
            else
            {
                pracownik = null;
                UpdateUI(); 
            }
        }
        public void UpdateUI()
        {
            if (pracownik != null)
            {
                ObecnyUzytkownikLabel.Content = pracownik.PESEL;
                LogInBtn.Content = "Wyloguj";
                Tabs.Visibility = Visibility.Visible;
            }
            else
            {
                Tabs.Visibility = Visibility.Hidden;
                ObecnyUzytkownikLabel.Content = "Niezalogowano";
                LogInBtn.Content = "Zaloguj";
            }
        }


       
    }
}
