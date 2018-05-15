using Hotel.Web.Areas.ModulAdministracija.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulAdministracija.ViewModels
{
    public class NovaUslugaHotelaVM
    {
        public int Id { get; set; }

        [StringLength(maximumLength:30,MinimumLength =2,ErrorMessage ="Naziv ne smije biti manje od 2 a veće od 30 slova.")]
        [Required(ErrorMessage ="Naziv je obavezan!")]
        public string Naziv { set; get; }

        public float Cijena { set; get; }

        [Required(ErrorMessage = "Datum početka je obavezan!")]
        public DateTime DatumPocetka { set; get; }

        [Required(ErrorMessage = "Datum završetka je obavezan!")]
        [Remote(action:nameof(UslugeHotelaController.ProvjeraDatuma),controller:"UslugeHotela",AdditionalFields =nameof(DatumPocetka))]
        public DateTime DatumZavrsetka { set; get; }

        public string Opis { set; get; }
    }
}
