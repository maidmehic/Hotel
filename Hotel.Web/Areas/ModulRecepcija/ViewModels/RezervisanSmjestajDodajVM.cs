using Hotel.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulRecepcija.ViewModels
{
    public class RezervisanSmjestajDodajVM
    {
        public int Id { set; get; }

        public Gost Gost { get; set; }

        public SelectList Gosti { get; set; }

        public CheckIN CheckIN { get; set; }

        public SelectList Checkini { get; set; }
        public Smjestaj Smjestaj { get; set; }

        public SelectList Smjestaji { get; set; }
    }
}
