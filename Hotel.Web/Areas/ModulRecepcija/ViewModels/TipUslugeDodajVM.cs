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
        [Required]
        public string Naziv { set; get; }
        [Required]
        public float Cijena { get; set; }

    }
}
