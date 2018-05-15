using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulRecepcija.ViewModels
{
    public class RezervisanSmjestajProvjeriSlobodanSmjestajVM
    {


       public List<Row> lista { get; set; }

        public class Row
        {

           public string Opis { get; set; }
         
            public double Cijena { set; get; }

            //jedna vrsta smjestaja
           
            public string VrstaSmjestaja { get; set; }
        }

    }
}
