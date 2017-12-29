using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreASPNET.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreASPNET.Controllers
{
    [VerifyUser]
    public class BioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}