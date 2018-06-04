using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hotel.Web.Models;

namespace Hotel.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //return View();
            return RedirectToAction("Index", "Index",new { area = "ModulRecepcija" });
        }
        

    }
}
