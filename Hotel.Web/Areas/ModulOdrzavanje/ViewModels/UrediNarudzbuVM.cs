using Hotel.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulRecepcija.ViewModels
{
    public class UrediNarudzbuVM
    {

        public int Id { set; get; }
        public DateTime DatumKreiranja { set; get; }
        public string Hitnost { set; get; }
        public string Opis { set; get; }




    }
}
