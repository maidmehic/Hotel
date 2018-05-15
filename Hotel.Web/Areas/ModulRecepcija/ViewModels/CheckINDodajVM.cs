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
        [Required]
        public DateTime DatumDolaska { get; set; }
        [Required]
        public DateTime DatumOdlaska { get; set; }
        [Required]
        public int BrojDjece { get; set; }
    
        [Required]
        public int BrojOdraslih { get; set; }
        [Required]
        public float Depozit { get; set; }
        public string Napomena { get; set; }
        [Required]
        public int ZaposlenikId { get; set; }


        public Gost Gost { get; set; }
    
        public SelectList Gosti { get; set; }
       
        public TipUsluge TipUsluge { get; set; }
      
        public SelectList TipoviUsluga { get; set; }
    }
}
