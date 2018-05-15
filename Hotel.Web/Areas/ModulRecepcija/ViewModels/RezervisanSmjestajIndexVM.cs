using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulRecepcija.ViewModels
{
    public class RezervisanSmjestajIndexVM
    {
        public List<Row> smjestaji { get; set; }
        public class Row
        {
            public int Id { set; get; }

            public string Gost { get; set; }

            public int GostId { get; set; }
          

            public string CheckIN { get; set; }
            public int CheckINID { get; set; }

            public string Smjestaj { get; set; }

            
        }

    }
}
