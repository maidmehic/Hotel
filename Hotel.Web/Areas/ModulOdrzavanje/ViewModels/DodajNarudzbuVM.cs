using Hotel.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulOdrzavanje.ViewModels
{
    public class DodajNarudzbuVM
    {
        public int Id { set; get; }
        public DateTime DatumKreiranja { set; get; }
        public string Hitnost { set; get; }
        public string Opis { set; get; }

       public int ZaposlenikId { get; set; }
      

    }
}
