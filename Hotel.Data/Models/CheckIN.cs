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

    }
}
