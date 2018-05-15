using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulRecepcija.ViewModels
{
    public class ZahtjevZaCiscenjemIndexVM
    {

        public List<Row> zahtjevi { get; set; }
        public class Row
        {
            public int Id { set; get; }
            public DateTime DatumZahtjeva { set; get; }
            public string Prioritet { set; get; }
            public string Opis { set; get; }

            public string Zaposlenik { get; set; }
      
            public string Smjestaj { get; set; }

            public bool Obavljen { get; set; }
        }
    }
}
