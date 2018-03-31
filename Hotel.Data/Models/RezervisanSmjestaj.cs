using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Data.Models
{
    public class RezervisanSmjestaj
    {
        public int Id { set; get; }

        public int SmjestajId { get; set; }
        [ForeignKey(nameof(SmjestajId))]
        public virtual Smjestaj Smjestaj { get; set; }

        public int CheckINId { get; set; }
        [ForeignKey(nameof(CheckINId))]
        public virtual CheckIN CheckIN { get; set; }
    }
}
