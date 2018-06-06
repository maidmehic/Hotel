using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulRecepcija.ViewModels
{
    public class ProizvodDodajVM
    {

        public int ID { set; get; }
        [Required(ErrorMessage = "Naziv je obavezan")]
        public string Naziv { set; get; }
        [Required(ErrorMessage = "Vrsta je obavezna")]
        public string Vrsta { set; get; }
        [Range(0.01, 100.00,
            ErrorMessage = "Cijena mora biti izmedu 0.01 i 100")]
        public float Cijena { set; get; }

        [Required(ErrorMessage = "Mjerna jedinica je obavezna")]
        public string MjernaJedinica { set; get; }

        public int NarudzbaId { set; get; }

    }
}
