using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Data.Models
{
    public class Proizvodi
    {
        public int Id { set; get; }
        public string Naziv { set; get; }
        public string Vrsta { set; get; }
        public float Cijena { set; get; }
        public float Kolicina { set; get; }
        public string MjernaJedinica { set; get; }
    }
}
