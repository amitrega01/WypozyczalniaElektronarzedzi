﻿using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ModelBazy;
using WypozyczalniaElektronarzedzi;

namespace WypozyczalniaElektronarzedzi
{
    /// <summary>
    /// Logika interakcji dla klasy DodawaniePracownika.xaml
    /// </summary>
    public partial class DodawaniePracownika : UserControl
    {
        public DodawaniePracownika()
        {
            InitializeComponent();
            using (var context = new WypozyczalniaEntities())
            {
                var punktyObslugi = context.PunktyObslugi.ToList();
                PunktObslugi.ItemsSource = punktyObslugi;
                PunktObslugi.DisplayMemberPath = "Miasto";
            }
        }


        private void CreatePracownikBtn_Click(object sender, RoutedEventArgs e)
        {
            Pracownicy pracownik = new Pracownicy
            {
                Imie = ImieTextBox.Text,
                Nazwisko = NazwiskoTextBox.Text,
                PESEL = PESELTextBox.Text,
                Haslo = HasloTextBox.Text,
                IDPunktuObslugi= (PunktObslugi.SelectedItem as PunktyObslugi).IDPunktuObslugi,
                DataZatrudnienia = DateTime.Now
            };

            using (var context = new WypozyczalniaEntities())
            {
                context.Pracownicy.Add(pracownik);
                context.SaveChanges();
            }

            MainWindow.AppWindow.WyswietlaniePracownikowUC.UpdateUI();
            ImieTextBox.Text = String.Empty;
            NazwiskoTextBox.Text = String.Empty;
            PESELTextBox.Text = String.Empty;
            HasloTextBox.Text = String.Empty;
        }
    }
}