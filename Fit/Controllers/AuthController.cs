using System;
using System.Linq.Expressions;
using Fit.ViewModels.Auth;
using Interfaces;
using Logic;
using Logic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fit.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserLogic _userLogic = new UserLogic();
        private const string SessionKeyName = "_UserId";
        public IUser IsLoggedIn(HttpContext httpContext)
        {
            int userId;
            var success = int.TryParse(httpContext.Session.GetString(SessionKeyName), out userId);
            if (success)
            {
                return _userLogic.GetBy(userId);
            }
            return null;
        }

        public bool IsAdmin(HttpContext httpContext)
        {
            var user = IsLoggedIn(httpContext);
            return _userLogic.IsAdmin(user.Id);
        }

        public bool IsAdmin(int id)
        {
            return _userLogic.IsAdmin(id);
        }
        
        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }
        
        [HttpPost("Login")]
        public IActionResult Login(LoginViewModel data)
        {
            var message = _userLogic.CheckLogin(data.Email, data.Password);
            if (message.Type == MessageType.Success)
            {
                IUser currentUser = _userLogic.GetBy(data.Email);

                HttpContext.Session.SetString(SessionKeyName, currentUser.Id.ToString());
                     
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            data.Message = message;
            data.Password = "";
            
            return View("Login", data);
        }
        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove(SessionKeyName);

            return RedirectToAction("Index", "Home", new { area = "" });
        }

    }
}