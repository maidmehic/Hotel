using Hotel.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulRecepcija.ViewModels
{
    public class CheckINDodajVM
    {
        public int Id { set; get; }
        [Required(ErrorMessage ="Datum dolaska je obavezan")]
        public DateTime DatumDolaska { get; set; }
        [Required(ErrorMessage ="Datum odlaska je obavezan")]
        public DateTime DatumOdlaska { get; set; }
        [Required(ErrorMessage ="Broj djece je obavezan")]
        [RangeAttribute(0,10,ErrorMessage ="Broj djece ne može biti negativan ili veći od 10")]
        public int BrojDjece { get; set; }
    
        [Required(ErrorMessage = "Broj odraslih je obavezan")]
        [RangeAttribute(1, 5, ErrorMessage = "Broj odraslih ne može biti 0 ili veći od 5")]
        public int BrojOdraslih { get; set; }
        
        public string Napomena { get; set; }
       
        public int ZaposlenikId { get; set; }

        public int GostId { get; set; }
       
       
        public TipUsluge TipUsluge { get; set; }
      
        public SelectList TipoviUsluga { get; set; }
    }
}
