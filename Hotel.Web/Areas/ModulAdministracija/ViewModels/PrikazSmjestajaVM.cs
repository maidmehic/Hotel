using Hotel.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulAdministracija.ViewModels
{
    public class PrikazSmjestajaVM
    {
        public List<Smjestaj> Smjestaji { set; get; }
        public int BrojPretraga { set; get; }
    }
}
