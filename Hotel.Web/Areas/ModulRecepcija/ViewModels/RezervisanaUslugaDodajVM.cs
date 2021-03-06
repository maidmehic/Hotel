﻿using Hotel.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulRecepcija.ViewModels
{
    public class RezervisanaUslugaDodajVM
    {
        public int Id { set; get; }

        public string Rezervacija { get; set; }
        public string Datum { get; set; }
        public string Gost { get; set; }
        
        public int CheckINId { get; set; }


        [Required(ErrorMessage ="Usluga obavezna")]
        public int UslugaId{ get; set; }
     
        public SelectList UslugeHotela { get; set; }
      
       
    }
}
