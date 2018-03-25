using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Data.Models
{
    public class Zaposlenik
    {
        public int Id { set; get; }
        public string Ime { set; get; }
        public string Prezime { set; get; }
        public DateTime DatumRodjenja { set; get; }
        public string Telefon { set; get; }
        public string BracniStatus { set; get; }
        public string Email { set; get; }
        public string BrojUgovora { set; get; }
        public DateTime DatumZaposljenja { set; get; }
        public string JMBG { set; get; }
        public string Spol { set; get; }
        public bool Aktivan { set; get; }
        public bool isAdministrator { set; get; }
        public bool isRecepcioner { set; get; }
        public bool isCistacica { set; get; }
        public bool isKuhar { set; get; }


        public string username { set; get; }
        public string password { set; get; }


        //jedan grad
        public int GradId { get; set; }
        [ForeignKey(nameof(GradId))]
        public virtual Grad Grad { get; set; }
    }
}
