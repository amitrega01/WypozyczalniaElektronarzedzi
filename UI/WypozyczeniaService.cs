using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;
using ModelBazy;

namespace UI
{
    public class WypozyczeniaService
    {
        public List<WypozyczenieView> listaWypozyczen { get; set; }

        public WypozyczeniaService()
        {
            using (var context = new WypozyczalniaEntities())
            {
                listaWypozyczen = context.WypozyczenieViews.OrderBy(x => x.DataWypozyczenia).ToList();
            }
        }

        public List<WypozyczenieView> Lista()
        {
            using (var context = new WypozyczalniaEntities())
            {
                return null;

            }
        }
    }
}