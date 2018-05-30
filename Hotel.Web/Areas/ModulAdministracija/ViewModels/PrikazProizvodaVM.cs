using Hotel.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulAdministracija.ViewModels
{
    public class PrikazProizvodaVM
    {
        public List<Proizvodi> Proizvodi { get; set; }

        public string NazivPretraga { set; get; }
        public int VrstaOdabir { set; get; }
        public IEnumerable<SelectListItem> vrstaStavke
        {
            get
            {
                List<SelectListItem> _stavke = new List<SelectListItem>();
                _stavke.Add(new SelectListItem()
                {
                    Value = null,
                    Text = "Sve"
                });
                _stavke.Add(new SelectListItem()
                {
                    Value = 1.ToString(),
                    Text = "Hrana"
                });
                _stavke.Add(new SelectListItem()
                {
                    Value = 2.ToString(),
                    Text = "Pića"
                });

                return _stavke;
            }
        }
    }
}
