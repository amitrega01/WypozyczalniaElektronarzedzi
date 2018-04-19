using System;
using System.Collections.Generic;
using System.Linq;
using ModelBazy;
using UI.Interfaces;

namespace UI
{
    public class PracownicyService : IService
    {
        public List<Pracownicy> Pracownicy { get; set; }

        private WypozyczalniaEntities context;

        public PracownicyService()
        {
            context = new WypozyczalniaEntities();

            Pracownicy = context.Pracownicy.ToList();
        }

        public void AddEntity(Pracownicy entity)
        {
          
        }

        public void Dispose()
        {
            context?.Dispose();
        }

        public void AddEntity<T>(T entity)
        {
            context.Pracownicy.Add(entity as Pracownicy);
            context.SaveChanges();
        }

        public int GetMax()
        {
            throw new NotImplementedException();
        }
    }
}