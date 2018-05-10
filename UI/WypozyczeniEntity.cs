using System;
using System.Collections.ObjectModel;
using ModelBazy;

namespace UI
{
    public class WypozyczenieEnitity
    {
        public Wypozyczenie _wypozyczenie { get; set; }
        public ObservableCollection<PelnyProdukt> produkty { get; set; }
        public Klienci klient { get; set; }
        public DateTime dataDoZwrotu;
        public decimal zaDzien { get; set; }
        public decimal kaucja { get; set; }
        public string IDPrac  { get; set; }
        public WypozyczenieEnitity()
        {
            _wypozyczenie = new Wypozyczenie();
            produkty = new ObservableCollection<PelnyProdukt>();
            klient = new Klienci();
        }

        public void UpdateCeny()
        {
            zaDzien = 0;
            kaucja = 0;
            foreach (var p in produkty)
            {
                zaDzien += p.CenaZaDobe;
                kaucja += p.Kaucja;
            }
        }
    }
}