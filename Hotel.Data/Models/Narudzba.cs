using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Data.Models
{
    public class Narudzba
    {
        public int Id { set; get; }
        public DateTime DatumKreiranja { set; get; }
        public string Hitnost { set; get; }
        public string Opis { set; get; }
        // jedan zaposlenik
        public int ZaposlenikId { get; set; }
        [ForeignKey(nameof(ZaposlenikId))]
        public virtual Zaposlenik Zaposlenik { get; set; }
    }
}
