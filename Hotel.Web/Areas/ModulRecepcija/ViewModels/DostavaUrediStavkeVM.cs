﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulRecepcija.ViewModels
{
    public class DostavaUrediStavkeVM
    {
        public int StavkaId { get; set; }
        public int DostavaId { get; set; }
            
        public string Proizvod { get; set; }

        public int Kolicina { get; set; }
    }
}
