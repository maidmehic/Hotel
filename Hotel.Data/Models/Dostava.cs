using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hotel.Data.Models
{
     public class Dostava
    {
        public int Id { get; set; }
        public int Kolicina { get; set; }
        public float Cijena { get; set; }
        public string Naziv { get; set; }

        public int RezervisanSmjestajId { get; set; }
        [ForeignKey(nameof(RezervisanSmjestajId))]
        public virtual RezervisanSmjestaj RezervisanSmjestaj { get; set; }

    }
}
