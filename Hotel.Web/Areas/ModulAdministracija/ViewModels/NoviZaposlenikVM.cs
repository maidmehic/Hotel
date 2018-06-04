using Hotel.Data.Models;
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
    public class NoviZaposlenikVM
    {
        public int Id { set; get; }
        
        [Required(ErrorMessage ="Ime je obavezno!")]
        [StringLength(maximumLength:30,MinimumLength =2,ErrorMessage ="Ime ne smije biti manje od 2 a veće od 30 slova.")]
        [RegularExpression(@"^[a-žA-Ž]+$", ErrorMessage = "Koristiti samo slova!")]
        public string Ime { set; get; }

        [Required(ErrorMessage = "Prezime je obavezno!")]
        [StringLength(maximumLength: 30, MinimumLength = 2, ErrorMessage = "Prezime ne smije biti manje od 2 a veće od 30 slova.")]
        [RegularExpression(@"^[a-žA-Ž]+$", ErrorMessage = "Koristiti samo slova!")]
        public string Prezime { set; get; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Datum rođenja je obavezan!")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",ApplyFormatInEditMode =true)] 
        public DateTime DatumRodjenja { set; get; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Telefon je obavezan!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Uneseni format nije validan.")]
        public string Telefon { set; get; }

        [Remote(action:nameof(ZaposlenikController.ProvjeriBracniStatus), controller:"Zaposlenik")]
        public string BracniStatus { set; get; }
        
        [Required(ErrorMessage ="E-mail je obavezan")]
        [EmailAddress(ErrorMessage = "E-mail nije validan")]
        public string Email { set; get; }

        [Required(ErrorMessage = "Broj ugovora je obavezan")]
        public string BrojUgovora { set; get; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Datum zaposljenja je obavezan!")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DatumZaposljenja { set; get; }

        [Required(ErrorMessage = "JMBG je obavezan!")]
        [StringLength(maximumLength:13,MinimumLength =13,ErrorMessage ="JMBG mora imati 13 cifri.")]
        public string JMBG { set; get; }

        [Remote(action: nameof(ZaposlenikController.ProvjeriSpol), controller: "Zaposlenik")]
        public string Spol { set; get; }
        
        public bool Aktivan { set; get; }
        public bool isAdministrator { set; get; }
        public bool isRecepcioner { set; get; }
        public bool isCistacica { set; get; }
        public bool isKuhar { set; get; }

        [Remote(action: nameof(ZaposlenikController.ProvjeriGrad), controller: "Zaposlenik")]
        public int GradId { get; set; }



        public IEnumerable<SelectListItem> gradoviStavke { set; get; }
        public IEnumerable<SelectListItem> spoloviStavke { set; get; }
        public IEnumerable<SelectListItem> brakStavke { set; get; }
       
    }
}
