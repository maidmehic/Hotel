using Hotel.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulRecepcija.ViewModels
{
    public class RezervisanaUslugaDodajVM
    {
        public int Id { set; get; }
       
        public UslugeHotela Usluga{ get; set; }
     
        public SelectList UslugeHotela { get; set; }
      
        public CheckIN CheckIN { get; set; }
      
        public SelectList Checkini { get; set; }
    }
}
