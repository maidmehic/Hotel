using Hotel.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulRecepcija.ViewModels
{
    public class ZahtjevZaCiscenjemOznaciObavljenimVM
    {
         public List<Zaposlenik> lista { get; set; }
        public int ZahtjevID { get; set; }
        public int CistacicaID { get; set; }
    }
}
