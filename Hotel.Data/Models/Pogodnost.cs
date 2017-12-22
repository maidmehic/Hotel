using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Data.Models
{
    public class Pogodnost
    {
        public int Id { set; get; }
        public string Opis { set; get; }
        // vise pogodnosti smjestaja

        public virtual List<PogodnostiSmjestaja> PogodnostiSmjestaja { get; set; }
    }
}
