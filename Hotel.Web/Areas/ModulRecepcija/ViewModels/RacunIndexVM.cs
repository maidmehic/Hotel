using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulRecepcija.ViewModels
{
    public class RacunIndexVM
    {

        public List<Row> racuni { get; set; }
        public class Row
        {
            public int Id { get; set; }
            public DateTime DatumIzdavanja { set; get; }
            public double Suma { set; get; }
          
           
            public string CheckIN { get; set; }
        
            
            public string Gost { get; set; }
        }
    }
}
