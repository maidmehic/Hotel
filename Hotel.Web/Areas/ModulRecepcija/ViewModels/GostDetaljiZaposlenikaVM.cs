using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulRecepcija.ViewModels
{
    public class GostDetaljiZaposlenikaVM
    {
        public int Id { set; get; }
        public string ImePrezime { set; get; }
       
        public string DatumRodjenja { set; get; }
        public string Telefon { set; get; }
    
        public string Email { set; get; }
     
       
        public string Spol { set; get; }
      
        public string  Grad { get; set; }
    }
}
