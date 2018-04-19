using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelBazy;
using UI.Interfaces;

namespace UI
{
    public class ProduktyService : IService
    {
        public List<PelnyProdukt> produktyList { get; set; }

        private WypozyczalniaEntities context;

        public ProduktyService()
        {
            context = new WypozyczalniaEntities();
            produktyList = context.PelnyProdukt.ToList();
        }

        public void AddEntity<T>(T entity)
        {
            var entityTuple = entity as Tuple<Produkty, ProduktySz>;
            if (entityTuple.Item1 != null)
            {
                context.Produkty.Add(entityTuple.Item1);
            }

            context.ProduktySz.Add(entityTuple.Item2);
            context.SaveChanges();
        }

        public int GetMax()
        {
            return context.Produkty.Select(x => x.IDProduktu).Max() + 1;
        }

        public int GetMaxSz()
        {
            return context.ProduktySz.Select(x => x.IDProduktuSZ).Max() + 1;
        }

        public void Dispose()
        {
            context?.Dispose();
        }
    }
}