using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hotel.Data.Models
{
   public class DostavaStavke
    {
        public int Id { get; set; }
        public int DostavaId { get; set; }
        [ForeignKey(nameof(DostavaId))]
        public virtual Dostava Dostava { get; set; }

        public int ProizvodId { get; set; }  
        [ForeignKey(nameof(ProizvodId))]
        public virtual Proizvodi Proizvod { get; set; }

        public int Kolicina { get; set; }

    }
}
