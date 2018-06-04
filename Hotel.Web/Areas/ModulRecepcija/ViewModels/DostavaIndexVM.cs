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
            public int DostavaId { get; set; }
            public string Datum { get; set; }
            public bool Zavrsena { get; set; }           
            public string RezervisanSmjestaj { get; set; }
            public int BrojStavki { get; set; }

        }
    }
}
