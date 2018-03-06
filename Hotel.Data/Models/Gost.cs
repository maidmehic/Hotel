using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Data.Models
{
    public class Gost
    {
        public int Id { set; get; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojPasosa { get; set; }
        public string Drzavljanstvo { get; set; }
        public DateTime DatumRodenja { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Spol { get; set; }

        public int GradId { get; set; }
        [ForeignKey(nameof(GradId))]
        public virtual Grad Grad { get; set; }
    }
}
