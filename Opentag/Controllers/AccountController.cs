using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opentag.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login(string username, string password)
        {

            return View();

        }

        [HttpPost]
        public IActionResult Login()
        {

            return View();

        }
    }
}
