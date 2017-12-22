using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Data.Models
{
    public class PogodnostiSmjestaja
    {
        public int Id { set; get; }
        public string Napomena { set; get; }
        // jedan smjestaj
        public int SmjestajId { get; set; }
        [ForeignKey(nameof(SmjestajId))]
        public virtual Smjestaj Smjestaj { get; set; }
        // jedna pogodnost
        public int PogodnostId { get; set; }
        [ForeignKey(nameof(PogodnostId))]
        public virtual Pogodnost Pogodnost { get; set; }
    }
}
