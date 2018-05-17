using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Documents;
using ModelBazy;
using UI.Interfaces;

namespace UI
{
    public class WypozyczeniaService : IService
    {
        public ObservableCollection<WypozyczenieView> listaWypozyczen { get; set; }

        private WypozyczalniaEntities context;

        public WypozyczeniaService()
        {
            context = new WypozyczalniaEntities();

            Refresh();
        }


        public void AddEntity<T>(T entity1)
        {
            var entity = entity1 as WypozyczenieEnitity;
            List<WypozyczenieSz> tempList = new List<WypozyczenieSz>();

            Wypozyczenie temp = new Wypozyczenie
            {
                IDWypozyczenia = context.Wypozyczenie.Select(x => x.IDWypozyczenia).Max() + 1,
                DataDoZwrotu = entity.dataDoZwrotu,
                DataWypozyczenia = DateTime.Now,
                IDPracWydajacego = entity.IDPrac,
                IDKlienta = entity.klient.PESEL
            };
            foreach (var p in entity.produkty)
            {
                tempList.Add(new WypozyczenieSz
                {
                    IDWypozyczenia = temp.IDWypozyczenia,
                    IDProduktuSz = p.ID
                });
            }

            context.Wypozyczenie.Add(temp);
            foreach (var wypozyczenieSz in tempList)
            {
                context.WypozyczenieSz.Add(wypozyczenieSz);
            }

            context.SaveChanges();
        }

        public int GetMax()
        {
            throw new System.NotImplementedException();
        }

        public void DeleteEntity(int id)
        {
            var entity = context.Wypozyczenie.Single(x => x.IDWypozyczenia == id);
            var szczegolowe = context.WypozyczenieSz.Where(x => x.IDWypozyczenia == entity.IDWypozyczenia).ToList();

            foreach (var wypozyczenieSz in szczegolowe)
            {
                context.WypozyczenieSz.Remove(wypozyczenieSz);
            }


            context.Wypozyczenie.Remove(entity);
            context.SaveChanges();
        }

        public void Zwrocenie(int id, string pracownikPesel)
        {
            var temp = DateTime.Now;
            
            context.Wypozyczenie.Single(x => x.IDWypozyczenia == id).DataZwrotu = temp;
            context.Wypozyczenie.Single(x => x.IDWypozyczenia == id).IDPracOdbierajacego = pracownikPesel;
            context.SaveChanges();
           

        }

        public void Refresh()
        {
            listaWypozyczen =
                new ObservableCollection<WypozyczenieView>(context.WypozyczenieViews.OrderBy(x => x.DataWypozyczenia)
                );
        }

        public void Dispose()
        {
            context?.Dispose();
        }

        public List<Produkty> GetSzczegolowe(int tempId)
        {
            return context.WypozyczenieSz.Where(x => x.IDWypozyczenia == tempId).Select(x => x.ProduktySz)
                .Select(x => x.Produkty).ToList();
        }
    }
}