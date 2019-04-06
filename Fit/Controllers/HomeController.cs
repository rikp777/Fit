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

        public HomeController()
        {
            var authUser = _auth.GetIsLoggedIn(HttpContext);
            ViewData["AuthUser"] = authUser;      
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }

    public class Exepction : Exception
    {
    }
}
