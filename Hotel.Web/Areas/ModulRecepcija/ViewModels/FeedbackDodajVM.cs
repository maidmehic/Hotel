using Hotel.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulRecepcija.ViewModels
{
    public class FeedbackDodajVM
    {
        public int Id { get; set; }
        public string Sadrzaj { set; get; }
       
        public int CheckINId { get; set; }
      
      
      
        public int GostId { get; set; }
       
   
    }
}
