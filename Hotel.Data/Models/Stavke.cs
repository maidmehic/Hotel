using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Data.Models
{
    public class Stavke
    {
        public int Id { set; get; }
        public int Kolicina { get; set; }
        //jedan proizvod
        public int ProizvodId { get; set; }
        [ForeignKey(nameof(ProizvodId))]
        public virtual Proizvodi Proizvodi { get; set; }
        //jedna narudzba
        public int NarudzbaId { get; set; }
        [ForeignKey(nameof(NarudzbaId))]
        public virtual Narudzba Narudzba { get; set; }

    }
}
