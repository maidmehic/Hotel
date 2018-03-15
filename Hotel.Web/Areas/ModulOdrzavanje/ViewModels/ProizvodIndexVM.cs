using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulOdrzavanje.ViewModels
{
    public class ProizvodIndexVM
    {
      
       public List<Row> Proizvodi { get; set; }

        public class Row
        {
            public string Naziv { set; get; }
            public string Vrsta { set; get; }
            public float Cijena { set; get; }
        }
    }
}
