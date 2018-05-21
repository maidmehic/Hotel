using Hotel.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulRecepcija.ViewModels
{
    public class RezervisanSmjestajOdaberiSmjestajVM
    {
        public string DatumDolaska { get; set; }
        public string DatumOdlaska { get; set; }
        public int GostId { get; set; }
        public int CheckInId { get; set; }



        public Smjestaj Smjestaj { get; set; }

        public SelectList Smjestaji { get; set; }
    }
}
