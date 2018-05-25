using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hotel.Data.Models
{
     public class Dostava
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public bool Zavrsena { get; set; }
        public int RezervisanSmjestajId { get; set; }
        [ForeignKey(nameof(RezervisanSmjestajId))]
        public virtual RezervisanSmjestaj RezervisanSmjestaj { get; set; }
      

    }
}
