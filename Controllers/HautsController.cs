using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DressMe.Controllers
{
    public class HautsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
