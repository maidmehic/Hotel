using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulRecepcija.ViewModels
{
    public class ProizvodDodajVM
    {
        
        public int ID { set; get; }
        public string Naziv { set; get; }
        public string Vrsta { set; get; }
        public float Cijena { set; get; }
    }
}
