using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulRecepcija.ViewModels
{
    public class CheckINCheckOutVM
    {
        public int CheckInId { get; set; }
        public double Iznos { get; set; }
        public string Prioritet { get; set; }
        public string Opis { get; set; }
    }
}
