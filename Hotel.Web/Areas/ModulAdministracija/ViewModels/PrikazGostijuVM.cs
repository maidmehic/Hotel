using Hotel.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulAdministracija.ViewModels
{
    public class PrikazGostijuVM
    {
        public List<Gost> Gosti { get; set; }
        public string ImePrezimePretraga { get; set; }
        public int? PretragaGrad { get; set; }
        public IEnumerable<SelectListItem> GradoviStavke { get; set; }
    }
}
