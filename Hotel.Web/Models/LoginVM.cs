using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Web.Models
{
    public class LoginVM
    {
        public string username { set; get; }
        public string password { set; get; }
        public bool zapamtiPassword { set; get; }
    }
}
