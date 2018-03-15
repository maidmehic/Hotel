using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulOdrzavanje.ViewModels
{
    public class PrikaziStavkeNarudzbeVM
    {


        public int IdNarudzbe { set; get; }
        public  List<Stavka> stavke { get; set; }

        public class Stavka
        {
            public int Kolicina { get; set; }
            public int StavkaId { get; set; }
            public string NazivProizvoda { get; set; }

        }
      
     
    }
}
