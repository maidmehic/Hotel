using Hotel.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulRecepcija.ViewModels
{
    public class CheckINDodajVM
    {
        public int Id { set; get; }
        public DateTime DatumDolaska { get; set; }
        public DateTime DatumOdlaska { get; set; }
        public int BrojDjece { get; set; }
        public int BrojOdraslih { get; set; }
        public float Depozit { get; set; }
        public string Napomena { get; set; }
      
        public int ZaposlenikId { get; set; }
       
       
      
        public Gost Gost { get; set; }
    
        public SelectList Gosti { get; set; }
       
        public TipUsluge TipUsluge { get; set; }
      
        public SelectList TipoviUsluga { get; set; }
    }
}
