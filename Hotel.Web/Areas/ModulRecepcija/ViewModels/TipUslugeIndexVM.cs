using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulRecepcija.ViewModels
{
    public class TipUslugeIndexVM
    {

        public List<Row> TipoviUsluga { get; set; }



        public class Row
        {
            public int Id { set; get; }
            public string Naziv { set; get; }
            public float Cijena { get; set; }
        }

    }
}
