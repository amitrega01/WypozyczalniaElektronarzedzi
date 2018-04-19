﻿using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;
using ModelBazy;
using UI.Interfaces;

namespace UI
{
    public class WypozyczeniaService :IService
    {
        public List<WypozyczenieView> listaWypozyczen { get; set; }

        private WypozyczalniaEntities context;

        public WypozyczeniaService()
        {
            context = new WypozyczalniaEntities();

            listaWypozyczen = context.WypozyczenieViews.OrderBy(x => x.DataWypozyczenia).ToList();
        }


        public void AddEntity<T>(T entity)
        {
            throw new System.NotImplementedException();
        }

        public int GetMax()
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            context?.Dispose();
        }
    }
}