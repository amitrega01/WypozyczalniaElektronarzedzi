using System.Collections.Generic;
using System.Linq;
using ModelBazy;
using UI.Interfaces;

namespace UI
{
    public class PunktyObslugiService :IService
    {
        public List<PunktyObslugi> PunktyObslugi { get; set; }

        private WypozyczalniaEntities context;

        public PunktyObslugiService()
        {
            context = new WypozyczalniaEntities();

            PunktyObslugi = context.PunktyObslugi.ToList();
        }

        public void AddEntity<T>(T entity)
        {
            context.PunktyObslugi.Add(entity as PunktyObslugi);
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