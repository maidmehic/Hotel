using Hotel.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulAdministracija.ViewModels
{
    public class PrikazZaposlenikaVM
    {
        public List<Zaposlenik> Zaposlenici { set; get; }
        public Zaposlenik Zaposlenik { set; get; } //koristi se prilikom prikaza detalja za jednog zaposlenika
        public int Tip { set; get; }
        public string ImePrezimePretraga { set; get; }
        public IEnumerable<SelectListItem> tipoviStavke { get
            {
                List<SelectListItem> _stavke = new List<SelectListItem>();
                _stavke.Add(new SelectListItem { Value = null, Text = "Svi zaposleni" });
                _stavke.Add(new SelectListItem { Value = 1.ToString(), Text = "Administratori" });
                _stavke.Add(new SelectListItem { Value = 2.ToString(), Text = "Čistači" });
                _stavke.Add(new SelectListItem { Value = 3.ToString(), Text = "Recepcioneri" });
                _stavke.Add(new SelectListItem { Value = 4.ToString(), Text = "Kuhari" });
                
                return _stavke;
            }
                
        }
    }
}
