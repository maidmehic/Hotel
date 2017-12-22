using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Data.Models
{
    public class CheckIN
    {
        public int Id { set; get; }
        public DateTime DatumDolaska { get; set; }
        public DateTime DatumOdlaska { get; set; }
        public int BrojDjece { get; set; }
        public int BrojOdraslih { get; set; }
        public float Depozit { get; set; }
        public string Napomena { get; set; }
        // jednog zaposlenika
        public int ZaposlenikId { get; set; }
        [ForeignKey(nameof(ZaposlenikId))]
        public virtual Zaposlenik Zaposlenik { get; set; }
        // jedan gost
        public int GostId { get; set; }
        [ForeignKey(nameof(GostId))]
        public virtual Gost Gost { get; set; }
        // jedan tip usluge
        public int TipUslugeId { get; set; }
        [ForeignKey(nameof(TipUslugeId))]
        public virtual TipUsluge TipUsluge { get; set; }
        // vise uplata

        public virtual List<Uplata> Uplata { get; set; }
        //vise rezervisanihUsluga

        public virtual List<RezervisanaUsluga> RezervisanaUsluga { get; set; } //ova lista sama dodaje checkIn u tabeli RezervisanaUsluga
                                                                               //PITANJE:- Da li su name potrebne liste
                                                                               //        - Da li nam duple veze pravi OnModelCreating
                                                                               //vise rezervisanihsmjestaja


        public virtual List<RezervisanSmjestaj> RezervisanSmjestaj { get; set; }
        //vise racuna


        public virtual List<Racun> Racun { get; set; }
        // vise feedbacka

        public virtual List<Feedback> Feedback { get; set; }

    }
}
