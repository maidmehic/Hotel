using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Data.Models
{
    public class UslugeHotela
    {
        public int Id { get; set; }
        public string Naziv { set; get; }
        public float Cijena { set; get; }
        public DateTime DatumPocetka { set; get; }
        public DateTime DatumZavrsetka { set; get; }
        public string Opis { set; get; }
    }
}
