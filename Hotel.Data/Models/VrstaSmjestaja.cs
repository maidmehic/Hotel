using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Data.Models
{
    public class VrstaSmjestaja
    {
        public int Id { set; get; }
        public string Naziv { set; get; }
        // vise smještaja

        public virtual List<Smjestaj> Smjestaj { get; set; }
    }
}
