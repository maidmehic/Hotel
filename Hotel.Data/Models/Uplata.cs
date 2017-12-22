using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Data.Models
{
    public class Uplata
    {
        public int Id { get; set; }
        public double Iznos { set; get; }
        public DateTime DatumUplate { set; get; }
        // jedan check in
        public int CheckINId { get; set; }
        [ForeignKey(nameof(CheckINId))]
        public virtual CheckIN CheckIN { get; set; }
    }
}
