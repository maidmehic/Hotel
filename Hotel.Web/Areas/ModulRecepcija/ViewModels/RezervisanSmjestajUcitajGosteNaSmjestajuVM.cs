using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulRecepcija.ViewModels
{
    public class RezervisanSmjestajUcitajGosteNaSmjestajuVM
    {
        public List<SelectListItem> Gosti { get; set; }
        public int GostId { get; set; }

    }
}
