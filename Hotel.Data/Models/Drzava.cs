using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Data.Models
{
    public class Drzava
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        // vise gradova


        public virtual List<Grad> Grad { get; set; }
    }
}
