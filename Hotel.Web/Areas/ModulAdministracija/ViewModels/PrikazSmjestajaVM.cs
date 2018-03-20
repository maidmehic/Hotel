using Hotel.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulAdministracija.ViewModels
{
    public class PrikazSmjestajaVM
    {
        public List<Smjestaj> Smjestaji { set; get; }
        public int ? BrojPretraga { set; get; }
        public int StatusPretraga { set; get; }
        public IEnumerable<SelectListItem> PretragaPoStatusu { get
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
                    Text = "Slobodni"
                });
                _stavke.Add(new SelectListItem()
                {
                    Value = 2.ToString(),
                    Text = "Zauzeti"
                });

                return _stavke;
            } }
    }
}
