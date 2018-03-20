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

     
        public Grad Grad { get; set; }

        public int Id { set; get; }
        [Required]
        [StringLength(25)]
        public string Ime { get; set; }
        [Required]
        [StringLength(25)]
        public string Prezime { get; set; }

        [Required]

        public string BrojPasosa { get; set; }
        [Required]

        public string Drzavljanstvo { get; set; }
        [Required]

        public DateTime DatumRodenja { get; set; }
        [Required]
        [RegularExpression("\\(\\d{3}\\)\\-\\d{3}\\-\\d{3}", ErrorMessage = "Broj telefona je u formatu (000)-000-000")]
        public string Telefon { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Unesite validnu Email adresu")]
        public string Email { get; set; }
        public string Spol { get; set; }


    }
}
