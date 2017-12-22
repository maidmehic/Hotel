using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Data.Models
{
    public class Racun
    {
        public int Id { get; set; }
        public DateTime DatumIzdavanja { set; get; }
        public double Suma { set; get; }
        // jedan check in 
        public int CheckINId { get; set; }
        [ForeignKey(nameof(CheckINId))]
        public virtual CheckIN CheckIN { get; set; }
        // jedan gost
        public int GostId { get; set; }
        [ForeignKey(nameof(GostId))]
        public virtual Gost Gost { get; set; }
    }
}
