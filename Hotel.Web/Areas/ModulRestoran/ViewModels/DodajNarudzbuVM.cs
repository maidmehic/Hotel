using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Areas.ModulRestoran.ViewModels
{
    public class DodajNarudzbuVM
    {
        public int Id { set; get; }
        public DateTime DatumKreiranja { get; set; }
        public string Opis { get; set; }
        public string Hitnost { get; set; }
        public int ZaposlenikId { set; get; }

        public IEnumerable <SelectListItem> HitnostStavke { get
            {
                List<SelectListItem> _stavke = new List<SelectListItem>();
                _stavke.Add(new SelectListItem()
                {
                    Value = null,
                    Text = "Odaberite hitnost"
                });
                _stavke.Add(new SelectListItem()
                {
                    Value = "Visoka",
                    Text = "Visoka"
                });
                _stavke.Add(new SelectListItem()
                {
                    Value = "Srednja",
                    Text = "Srednja"
                });
                _stavke.Add(new SelectListItem()
                {
                    Value = "Niska",
                    Text = "Niska"
                });
                return _stavke;
            } }
        
    }
}
