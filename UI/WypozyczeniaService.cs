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
    public class WypozyczeniaService :IService
    {
        public ObservableCollection<WypozyczenieView> listaWypozyczen { get; set; }

        private WypozyczalniaEntities context;

        public WypozyczeniaService()
        {
            context = new WypozyczalniaEntities();

            Refresh();
        }


        public void AddEntity<T>(T entity)
        {
            throw new System.NotImplementedException();
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

        public void Zwrocenie(int id)
        {
            var temp = context.Wypozyczenie.Find(id);
            context.SaveChanges();
            listaWypozyczen = new ObservableCollection<WypozyczenieView>(context.WypozyczenieViews.ToList());

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
    }
}