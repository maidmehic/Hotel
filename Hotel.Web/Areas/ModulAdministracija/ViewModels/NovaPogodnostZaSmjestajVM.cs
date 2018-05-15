using Hotel.Web.Areas.ModulAdministracija.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulAdministracija.ViewModels
{
    public class NovaPogodnostZaSmjestajVM
    {
        public int smjestajID { set; get; }

        [Remote(action: nameof(PogodnostController.ProvjeriStavkuPogodnosti), controller: "Pogodnost", AdditionalFields = nameof(smjestajID))]
        public int StavkaPogodnosti { get; set; }

        public IEnumerable<SelectListItem> _stavke { get; set; }
    }
}
