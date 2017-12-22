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

        //  više check in


        public virtual List<CheckIN> CheckIN { get; set; }
        // vise rezervisanih smjestaja


        public virtual List<RezervisanSmjestaj> RezervisanSmjestaj { get; set; }
        //vise racuna


        public virtual List<Racun> Racun { get; set; }
        // vise feedbacka


        public virtual List<Feedback> Feedback { get; set; }
        // jedan grad

        public int GradId { get; set; }
        [ForeignKey(nameof(GradId))]
        public virtual Grad Grad { get; set; }
    }
}
