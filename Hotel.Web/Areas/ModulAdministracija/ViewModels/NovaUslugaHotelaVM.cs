using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulAdministracija.ViewModels
{
    public class NovaUslugaHotelaVM
    {
        public int Id { get; set; }
        public string Naziv { set; get; }
        public float Cijena { set; get; }
        public DateTime DatumPocetka { set; get; }
        public DateTime DatumZavrsetka { set; get; }
        public string Opis { set; get; }
    }
}
