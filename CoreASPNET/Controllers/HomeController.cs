using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

using CoreModel.VO.User;
using CoreBackEnd.UserBiz;

namespace CoreASPNET.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult Login()
        {
            return PartialView();
        }

        [HttpGet]
        public PartialViewResult Regist()
        {
            return PartialView();
        }

        [HttpGet]
        public IActionResult Error()
        {
            return View();
        }

        [HttpPost]
        public String LoginUser(LoginUser user)
        {
            return JsonConvert.SerializeObject(LoginUserBiz.LoginAuth(user));
        }
    }
}