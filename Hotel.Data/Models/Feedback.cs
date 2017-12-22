using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Data.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public string Sadrzaj { set; get; }
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
