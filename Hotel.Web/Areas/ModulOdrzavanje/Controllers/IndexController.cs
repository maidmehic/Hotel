using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Web.Areas.ModulOdrzavanje.Controllers
{
    [Area("ModulOdrzavanje")]
    public class IndexController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}