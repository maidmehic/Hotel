using Hotel.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulAdministracija.ViewModels
{
    public class PrikazDetaljaZaCheckINVM
    {
        public List<RezervisanSmjestaj> RezervisanSmjestaj { set; get; }
        public List<RezervisanaUsluga> RezervisaneUsluge { set; get; }
        public int BrojGostiju{ get; set; }
        public int BrojRezSmjestaja{ get; set; }
    }
}
