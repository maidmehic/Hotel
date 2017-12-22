using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Data.Models
{
    public class RezervisanSmjestaj
    {
        public int Id { set; get; }
        //jedan smjestaj
        public int SmjestajId { get; set; }
        [ForeignKey(nameof(SmjestajId))]
        public virtual Smjestaj Smjestaj { get; set; }
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
