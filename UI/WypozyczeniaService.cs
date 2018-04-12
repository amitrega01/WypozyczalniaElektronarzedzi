using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;
using ModelBazy;

namespace UI
{
    public class WypozyczeniaService
    {
        public List<Wypozyczenie> listaWypozyczen { get; set; }

        public WypozyczeniaService()
        {
            using (var context = new WypozyczalniaEntities())
            {
                listaWypozyczen = context.Wypozyczenie.OrderBy(x => x.DataWypozyczenia).ToList();
            }
        }

        public List<WypozyczenieDto> Lista()
        {
            using (var context = new WypozyczalniaEntities())
            {
                return
                    context.Wypozyczenie
                        .Join(context.WypozyczenieSz, wypozyczenie => wypozyczenie.IDWypozyczenia,
                            sz => sz.IDWypozyczenia,
                            (wypozyczenie, sz) => new WypozyczenieDto()
                            {
                                ID = wypozyczenie.IDWypozyczenia,
                                DataWypozyczenia = wypozyczenie.DataWypozyczenia
                            }).ToList();
            }
        }
    }
}