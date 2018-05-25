using Hotel.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulRecepcija.ViewModels
{
    public class DostavaDodajStavkuVM
    {
       
        public int DostavaId { get; set; }
      
       public int RezervisanSmjestajId { get; set; }
        public int ProizvodId { get; set; }

        public List<Proizvodi> Proizvodi { get; set; }

        public int Kolicina { get; set; }
    }
}
