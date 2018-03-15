using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulAdministracija.ViewModels
{
    public class NoviSmjestajVM
    {
        public int Id { set; get; }
        public int BrojSmjestaja { set; get; }
        public int Sprat { set; get; }
        public int BrojKreveta { set; get; }
        public int Kvadratura { set; get; }
        public bool Zauzeto { set; get; }
        public int VrstaSmjestajaId { get; set; }
        public double Cijena { get; set; }
        public IEnumerable<SelectListItem> _vrstaStavke { set; get; }
    }
}
