using Hotel.Web.Areas.ModulAdministracija.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulAdministracija.ViewModels
{
    public class NovaPogodnostVM
    {
        public int Id { set; get; }

        [Required(ErrorMessage ="Opis je obavezan!")]
        [Remote(action:nameof(PogodnostController.ProvjeriDuplikate),controller:"Pogodnost",AdditionalFields =nameof(Id))]
        public string Opis { set; get; }
    }
}
