using Hotel.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulRestoran.ViewModels
{
    public class PrikaziDostaveVM
    {
        public List<Dostava> Dostave { get; set; }
        public int? StanjeOdabir { set; get; }

        public IEnumerable<SelectListItem> stanjeStavke { get {
                List<SelectListItem> _stavke = new List<SelectListItem>();

                _stavke.Add(new SelectListItem()
                {
                    Value = null,
                    Text = "Na čekanju"
                });

                _stavke.Add(new SelectListItem()
                {
                    Value = 1.ToString(),
                    Text = "Sve"
                });

                _stavke.Add(new SelectListItem()
                {
                    Value = 2.ToString(),
                    Text = "Završene"
                });
                return _stavke;
            }
        }
    }
}
