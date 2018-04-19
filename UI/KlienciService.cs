using System.Collections.Generic;
using System.Linq;
using ModelBazy;
using UI.Interfaces;

namespace UI
{
    public class KlienciService : IService
    {
        public List<Klienci> Klienci { get; set; }

        private WypozyczalniaEntities context;

        public KlienciService()
        {
            context = new WypozyczalniaEntities();
            Klienci = context.Klienci.ToList();
        }

        public void AddEntity<T>(T entity)
        {
            context.Klienci.Add(entity as Klienci);
            context.SaveChanges();
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