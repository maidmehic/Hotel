using Hotel.Data.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulRecepcija.ViewModels
{
    public class GostIndexVM
    {

        public List<Row> Gosti { get; set; }



        public class Row
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
            public string Grad { get; set; }
        }

       




    }
}
