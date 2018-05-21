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
            public int RezervisanSmjestajId { set; get; }

            public string Rezervisao { get; set; }

            public string OpisSobe { get; set; }


            public string BoraviOdDo { set; get; }

            public bool Zauzeto { set; get; }
          

            public string Gost { get; set; }
        }

    }
}
