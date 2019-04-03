using System;
using Fit.ViewModels.Auth;
using Microsoft.AspNetCore.Mvc;
using Interfaces;
using Logic;
using Microsoft.AspNetCore.Http;

namespace Fit.Controllers
{
    public class HomeController : Controller
    {
        private UserLogic _userLogic = new UserLogic();
        private AuthController _auth = new AuthController();
        
        [HttpGet]
        public IActionResult Index()
        {
            var user = _auth.IsLoggedIn(HttpContext);
            ViewData["AuthUser"] = user;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
