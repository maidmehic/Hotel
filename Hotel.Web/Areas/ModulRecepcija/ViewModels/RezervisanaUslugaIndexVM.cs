using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulRecepcija.ViewModels
{
    public class RezervisanaUslugaIndexVM
    {
   
        public List<Row> usluge { get; set; }

        public class Row
        {

            public int Id { set; get; }
            public int UslugeHotelaId { get; set; }
         
            public string UslugeHotela { get; set; }
            
            public int CheckINId { get; set; }
       
            public string  CheckIN { get; set; }


        }


    }
}
