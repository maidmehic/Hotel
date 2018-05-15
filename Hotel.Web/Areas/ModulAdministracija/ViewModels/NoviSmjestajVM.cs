using Hotel.Web.Areas.ModulAdministracija.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulAdministracija.ViewModels
{
    public class NoviSmjestajVM
    {
        public int Id { set; get; }

        [Required(ErrorMessage ="Broj smeštaja je obavezan!")]
        [Remote(action:nameof(SmjestajController.ProvjeriBroj),controller:"Smjestaj",AdditionalFields =nameof(Id))]
        [Range(1, 1000, ErrorMessage = "Broj mora biti veći od 0 i manji od 1000.")]
        public int? BrojSmjestaja { set; get; }

        [Required(ErrorMessage = "Sprat je obavezan!")]
        [Range(0, 3, ErrorMessage = "Broj mora biti u opsegu od 0 do 3.")]
        public int? Sprat { set; get; }
        
        [Required(ErrorMessage = "Broj kreveta je obavezan!")]
        [Range(1, 10, ErrorMessage = "Broj mora biti u opsegu od 1 do 10.")]
        public int? BrojKreveta { set; get; }

        [Required(ErrorMessage = "Broj kvadrata je obavezan!")]
        [Range(1, 500, ErrorMessage = "Broj mora biti u opsegu od 1 do 500.")]
        public int? Kvadratura { set; get; }

        public bool Zauzeto { set; get; }

        [Remote(action:nameof(SmjestajController.ProvjeriVrstu) ,controller:"Smjestaj")]
        public int VrstaSmjestajaId { get; set; }


        [Required(ErrorMessage = "Cijena je obavezna!")]
        [RegularExpression(@"^\d{0,10}(\.\d{0,2})?$",ErrorMessage ="Cijena mora biti pozitivan broj.")]
        public double? Cijena { get; set; }

        public IEnumerable<SelectListItem> _vrstaStavke { set; get; }
    }
}
