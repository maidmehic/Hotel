using Hotel.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulRestoran.ViewModels
{
    public class PrikaziNarudzbeVM
    {
        public int zaposlenikId { get; set; }//Ovo koristimo da bi stavili uslov da samo nosilac narudzbe moze uraditi edit


        public List<Narudzba> Narudzbe{ get; set; }
        public int StanjeOdabir { get; set; }
        public IEnumerable<SelectListItem> StanjeStavke{ get {
                List<SelectListItem> _stavke = new List<SelectListItem>();
                _stavke.Add(new SelectListItem()
                {
                    Value = null,
                    Text = "Sve"
                });
                _stavke.Add(new SelectListItem()
                {
                    Value = 1.ToString(),
                    Text = "Na čekanju"
                });
                _stavke.Add(new SelectListItem()
                {
                    Value = 2.ToString(),
                    Text = "Završene"
                });
                _stavke.Add(new SelectListItem()
                {
                    Value = 3.ToString(),
                    Text = "Otkazane"
                });
                return _stavke;
            } }
    }
}
