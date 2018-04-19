using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelBazy;

namespace UI
{
    public class KategorieService
    {
        public List<Kategorie> Kategorie { get; set; }
        private WypozyczalniaEntities context;

        public KategorieService()
        {
            context = new WypozyczalniaEntities();

            Kategorie = context.Kategorie.ToList();
        }

        public void AddEntity(Kategorie entity)
        {
            context.Kategorie.Add(entity);
            context.SaveChanges();
        }

        public int GetMax()
        {
            return context.Kategorie.Select(x => x.IDKategorii).Max() + 1;
        }
    }
}