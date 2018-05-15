using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulRecepcija.ViewModels
{
    public class DostavaDodajVM
    {
      
        public int Kolicina { get; set; }
        public float Cijena { get; set; }
        public string Naziv { get; set; }

        public int RezervisanSmjestajId { get; set; }
      



    }
}
