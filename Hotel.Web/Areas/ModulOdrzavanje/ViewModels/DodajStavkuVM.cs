using Hotel.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulOdrzavanje.ViewModels
{
    public class DodajStavkuVM
    {
        public int Id { set; get; }
        public int Kolicina { get; set; }
      
        public int ProizvodId { get; set; }
     
        public SelectList Proizvodi { get; set; }
      
        public Proizvodi Proizvod{ get; set; }

     
      
        public int NarudzbaId { get; set; }



    }
}
