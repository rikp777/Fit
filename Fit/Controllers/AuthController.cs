using System;
using System.Linq.Expressions;
using Enum;
using Fit.Models;
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
        private readonly RightLogic _rightLogic = new RightLogic();
        private const string SessionKeyName = "_UserId";
        public IUser GetAuth(HttpContext httpContext)
        {
            if (httpContext != null)
            {
                var success = int.TryParse(httpContext.Session.GetString(SessionKeyName), out int userId);
                if (success)
                {
                    return _userLogic.GetBy(userId);
                }
            }
            return null;
        }

        public bool CheckAuth(HttpContext httpContext)
        {
            if (GetAuth(httpContext) != null)
            {
                var success = int.TryParse(httpContext.Session.GetString(SessionKeyName), out int Id);
                if (success)
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckAuth(HttpContext httpContext, string right)
        {
            if (GetAuth(httpContext) != null)
            {
                var success = int.TryParse(httpContext.Session.GetString(SessionKeyName), out int id);
                if (success)
                {
                    var user = _userLogic.GetBy(id);
                    if (user.Right.Name == right)
                    {
                        return true;                   
                    }
                }
            }
            return false;
        }

        [HttpGet("Register")]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }
        [HttpPost("Register")]
        public IActionResult Register(RegisterViewModel data)
        {
            
            
            if (data.Password != data.PasswordH)
            {
                return View("Register", data);
            }
            var user = new User
            {
                FirstName = data.FirstName,
                LastName = data.LastName,
                Length = data.Length,
                BirthDate = data.BirthDate,
                Blocked = false,
                Email = data.Email,
                Right = _rightLogic.GetBy("Fitnesser")             
            };
            var success = _userLogic.Register(user, data.Password);
            if(success){
                return RedirectToAction("Login", "Auth");
            }           
            return View("Register", data);
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