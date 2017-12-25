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
        // vise gostiju

        public virtual List<Gost> Gost { get; set; }

        // vise zaposlenika

        public virtual List<Zaposlenik> Zaposlenik { get; set; }//test
    }
}
