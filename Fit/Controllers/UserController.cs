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
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {                               
            UserEditViewModel viewModel = new UserEditViewModel();
            
            
            var user = _userLogic.GetBy(id);
            viewModel.Id = user.Id;
            viewModel.Email = user.Email;
            viewModel.FirstName = user.Email;
            viewModel.LastName = user.LastName;
            viewModel.BirthDate = user.BirthDate;
            viewModel.Length = user.Length;
            viewModel.Right = user.Right as Right;
            
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(UserEditViewModel data)
        {
//            IUser user = data;
//            user.Right = _rightLogic.GetBy(data.Right.Id);
//            bool success = _userLogic.ChangeUser(user);
//            if (success)
//            {
//                return RedirectToAction("List");
//            }
//
            return View();
        }
        
    }
}