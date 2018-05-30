using Hotel.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulRecepcija.ViewModels
{
    public class GostDodajVM
    {

        public SelectList Gradovi { get; set; }

        [Required(ErrorMessage = "Grad je obavezan")]
        public int GradId { get; set; }

        public int Id { set; get; }
        [Required(ErrorMessage = "Ime je obavezno")]
        [StringLength(25)]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Prezime je obavezno")]
        [StringLength(25)]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "Broj pasoša je obavezan")]

        public string BrojPasosa { get; set; }
        [Required(ErrorMessage = "Drzavljanstvo je obavezno")]

        public string Drzavljanstvo { get; set; }
        [Required(ErrorMessage = "Datum rodenja je obavezan")]

        public DateTime DatumRodenja { get; set; }

        [Required(ErrorMessage = "Telefon je obavezan")]
        [RegularExpression("\\(\\d{3}\\)\\-\\d{3}\\-\\d{3}", ErrorMessage = "Broj telefona je u formatu (000)-000-000")]
        public string Telefon { get; set; }
        [Required(ErrorMessage = "Email je obavezan")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Unesite validnu Email adresu")]
        public string Email { get; set; }
        public string Spol { get; set; }


    }
}
