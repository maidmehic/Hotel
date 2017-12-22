using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Data.Models
{
    public class ZahtjevZaCiscenjem
    {
        public int Id { set; get; }
        public DateTime DatumZahtjeva { set; get; }
        public string Prioritet { set; get; }
        public string Opis { set; get; }
        // jedan zaposlenik
        public int ZaposlenikId { get; set; }
        [ForeignKey(nameof(ZaposlenikId))]
        public virtual Zaposlenik Zaposlenik { get; set; }
        // jedan smještaj
        public int SmjestajId { get; set; }
        [ForeignKey(nameof(SmjestajId))]
        public virtual Smjestaj Smjestaj { get; set; }
    }
}
