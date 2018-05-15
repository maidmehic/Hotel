using Hotel.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulRecepcija.ViewModels
{
    public class ZahtjevZaCiscenjemDodajVM
    {
        public int Id { set; get; }
        public DateTime DatumZahtjeva { set; get; }       
        public string Prioritet { set; get; }
        public string Opis { set; get; }
      

        public Smjestaj Smjestaj { get; set; }
       
        public SelectList Smjestaji { get; set; }
        public int? CistacicaID { get; set; }
        public bool Obavljen { get; set; }
    }
}
