using Hotel.Data.Models;
using Hotel.Web.Areas.ModulRestoran.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulRestoran.ViewModels
{
    public class PrikaziNarudzbuDodajProizvodeVM
    {
        public Narudzba Narudzba{ get; set; }//Ovo se prikazuje

        public int Id { set; get; }
        public int NarudzbaId { get; set; }
        
        public int ProizvodId { get; set; }

        [Required(ErrorMessage ="Količina je obavezna")]
        [Range(1,int.MaxValue,ErrorMessage = "Količina mora biti veća od 0.")]
        public int? Kolicina { set; get; }

        public IEnumerable<SelectListItem> ProizvodiStavke { set; get; }
    }
}
