using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Data.Models
{
    public class Smjestaj
    {
        public int Id { set; get; }
        public int BrojSmjestaja { set; get; }
        public int Sprat { set; get; }
        public int BrojKreveta { set; get; }
        public int Kvadratura { set; get; }

        //jedna vrsta smjestaja
        public int VrstaSmjestajaId { get; set; }
        [ForeignKey(nameof(VrstaSmjestajaId))]
        public virtual VrstaSmjestaja VrstaSmjestaja { get; set; }

    }
}
