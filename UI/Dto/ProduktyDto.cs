using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WypozyczalniaElektronarzedzi.UI
{
    public class ProduktyDto
    {
        public int ID { get; set; }
        public String Marka { get; set; }
        public String  Model { get; set; }
        public decimal Doba { get; set; }
        public decimal Kaucja { get; set; }
        public int IDKategorii { get; set; }
        public String PunktO { get; set; }
        public int StanTechniczny { get; set; }

    }
}
