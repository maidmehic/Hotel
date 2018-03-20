using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulOdrzavanje.ViewModels
{
    public class PrikaziNarudzbeVM
    {

       public  List<Row> podaci { get; set; }

        public class Row
        {
            public int Id { set; get; }
            public DateTime DatumKreiranja { set; get; }
            public string Hitnost { set; get; }
            public string Opis { set; get; }
            public string  ImeZaposlenika { get; set; }
        }
    }
}
