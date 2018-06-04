using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulRecepcija.ViewModels
{
    public class TipUslugeDodajVM
    {
        public int Id { set; get; }
        [Required(ErrorMessage ="Naziv je obavezan")]
        public string Naziv { set; get; }
        [Required(ErrorMessage ="Cijena je obavezna")]
        [Range(1,10000,ErrorMessage ="Cijena mora biti veca od 0")]
        public float Cijena { get; set; }

    }
}
