using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Data.Models
{
    public class Grad
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        //jednu drzavu
        public int DrzavaId { get; set; }
        [ForeignKey(nameof(DrzavaId))]
        public virtual Drzava Drzava { get; set; }
    }
}
