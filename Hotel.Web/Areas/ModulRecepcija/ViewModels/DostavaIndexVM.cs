using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulRecepcija.ViewModels
{
    public class DostavaIndexVM
    {

        public List<Row> dostave { get; set; }
        public class Row
        {
            public int Kolicina { get; set; }
            public float Cijena { get; set; }
            public string Naziv { get; set; }
            public string Gost { get; set; }
            public int RezervisanSmjestajId { get; set; }

        }
    }
}
