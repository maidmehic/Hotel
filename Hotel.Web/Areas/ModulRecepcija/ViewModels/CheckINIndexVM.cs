using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulRecepcija.ViewModels
{
    public class CheckINIndexVM 
    {

        public List<Row> CheckINI { get; set; }

      public int Brojac { get; set; }

        public class Row
        {
            public int Id { set; get; }
            public string DatumDolaska { get; set; }
            public string DatumOdlaska { get; set; }
            public int BrojDjece { get; set; }
            public int BrojOdraslih { get; set; }
            public float Depozit { get; set; }
            public string Napomena { get; set; }

            public string Zaposlenik { get; set; }

            public string BrojPasosa { get; set; }
            public string Gost { get; set; }
            public int GostId { get; set; }

            public string TipUsluge { get; set; }
        }
    }
}
