using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Data.Contexts.SQLContexts;
using Data.dto;
using Fit.ViewModels.Auth;
using Fit.ViewModels.User;
using Interfaces;
using Logic;
using Logic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fit.Controllers
{
    public class UserController : Controller
    {
        private readonly UserLogic _userLogic = new UserLogic();
        private readonly RightLogic _rightLogic = new RightLogic();
        private AuthController _auth = new AuthController();
        // GET

        [HttpGet]
        public IActionResult Edit()
        {            
            var authUser = _auth.GetAuth(HttpContext);
            ViewData["AuthUser"] = authUser;
            if (authUser != null)
            {
                UserEditViewModel viewModel = new UserEditViewModel();           
        
                var user = _userLogic.GetBy(authUser.Id);
                viewModel.Id = user.Id;
                viewModel.Email = user.Email;
                viewModel.FirstName = user.Email;
                viewModel.LastName = user.LastName;
                viewModel.BirthDate = user.BirthDate;
                viewModel.Length = user.Length;
                viewModel.Right = user.Right as Right;
        
                return View(viewModel);       
            }
            return RedirectToAction("Login", "Auth");
        }

        [HttpPost]
        public IActionResult Edit(UserEditViewModel data)
        {
            var user = _userLogic.GetBy(data.Id);
            user.FirstName = data.FirstName;
            user.LastName = data.LastName;
            user.BirthDate = data.BirthDate;
            user.Length = data.Length;
            
            var success = _userLogic.ChangeUser(user);          
            if (success)
            {
                return RedirectToAction("index", "Home");
            }
            return View(data);
        }
        
    }
}