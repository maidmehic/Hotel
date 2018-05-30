using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulRecepcija.ViewModels
{
    public class RezervisanSmjestajUcitajGosteNaSmjestajuVM
    {
        public List<Row> Gosti { get; set; }
        public class Row
        {
            public int GostId { get; set; }
            public string Gost { get; set; }
            public int SmjestajId { get; set; }

            public int CheckInId { get; set; }
        }
        

    }
}
