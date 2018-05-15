using Hotel.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulRestoran.ViewModels
{
    public class PrikaziNarudzbuDodajProizvodeVM
    {
        public Narudzba Narudzba{ get; set; }

        public int Id { set; get; }
        public int NarudzbaId { get; set; }
        public int ProizvodId { get; set; }
        public int? Kolicina { set; get; }
        public IEnumerable<SelectListItem> ProizvodiStavke { set; get; }
    }
}
