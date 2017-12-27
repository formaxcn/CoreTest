using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CoreASPNET.Controllers
{
    public class BioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}