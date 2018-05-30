using Hotel.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulRestoran.ViewModels
{
    public class PrikaziStavkeVM
    {
        public List<Stavke> Stavke{ get; set; }




        // Dodavanje novih stavki (KORISTI SE SAMO PRILIKOM EDITA NARUDZBE) //
        public int NarudzbaId { get; set; }
        public int ProizvodId { get; set; }

        [Required(ErrorMessage = "Količina je obavezna")]
        [Range(1, int.MaxValue, ErrorMessage = "Količina mora biti veća od 0.")]
        public int? Kolicina { set; get; }
        public IEnumerable<SelectListItem> ProizvodiStavke { set; get; }
    }
}
