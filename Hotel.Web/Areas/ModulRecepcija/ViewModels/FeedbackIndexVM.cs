using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulRecepcija.ViewModels
{
    public class FeedbackIndexVM
    {

        public List<Row> feedbaci { get; set; }
        public class Row
        {
            public int Id { get; set; }
            public string Sadrzaj { set; get; }

            public string CheckIN { get; set; }

            public int CheckINId { get; set; }

            public string Gost { get; set; }


        }
    }
}
