using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulRecepcija.ViewModels
{
    public class DostavaUrediVM
    {

        public string Datum { get; set; }
        public bool Zavrsena { get; set; }
        public string RezervisanSmjestaj { get; set; }

        public int DostavaId { get; set; }

        public List<row> stavke { get; set; }
        public class row
        {
            public int StavkaId { get; set; }
          
            public string Proizvod { get; set; }
            public int Kolicina { get; set; }
        }

    }
}
