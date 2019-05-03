using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;
using Data.Contexts;
using Data.Repositories;
using Enum;
using Fit.Models;
using Fit.ViewModels.Auth;
using Logic;
using Logic.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite.Internal.UrlActions;
using Models;

namespace Fit.Controllers
{
    public class AuthController : Controller
    {
        private readonly RightLogic _rightLogic;
        private readonly UserLogic _userLogic;

        public AuthController(RightLogic rightLogic, UserLogic userLogic)
        {
            _rightLogic = rightLogic;
            _userLogic = userLogic;
        }
            
        
        /// <summary>
        ///
        ///    Create
        /// 
        /// </summary>      
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
        
        
            
        /// <summary>
        ///
        ///    Login
        ///
        ///    Create Identity Cookie
        ///    Create Claims
        ///     
        /// </summary>         
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

                // Cookie Initialize 
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Sid, currentUser.Id.ToString()),
                    new Claim(ClaimTypes.Email, currentUser.Email),
                    new Claim(ClaimTypes.Name, currentUser.FirstName),
                    new Claim(ClaimTypes.Role, currentUser.Right.Name),
                }; 
                var clamIdentity = new ClaimsIdentity( claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(clamIdentity);
                
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true
                };
                // Cookie Initialize End
                
                HttpContext
                    .SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProperties)
                    .Wait(); 
                
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            data.Message = message;
            data.Password = "";
            
            return View("Login", data);
        }
        
        
        
        /// <summary>
        ///
        ///     Logout
        ///
        ///     Destroy Cookie
        /// 
        /// </summary>  
        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            HttpContext
                .SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }
        
        
        
            
        /// <summary>
        ///
        ///     GetAuthUser
        ///
        ///     By Identity Claims 
        /// 
        /// </summary>  
        public static int GetAuthUserId(ClaimsPrincipal user)
        {
            return int.Parse(user.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value);
        }
        public static IUser GetAuthUser(ClaimsPrincipal user)
        {
            return new UserLogic().GetBy(GetAuthUserId(user));
        }
    }
}