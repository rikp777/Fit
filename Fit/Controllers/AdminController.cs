using System;
using System.Collections.Generic;
using System.Linq;
using Fit.ViewModels.Admin;
using Fit.ViewModels.User;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fit.Controllers
{
    public class AdminController : Controller
    {       
        private readonly UserLogic _userLogic = new UserLogic();
        private readonly RightLogic _rightLogic = new RightLogic();
        private readonly AuthController _auth = new AuthController();

        public bool RightCheck()
        {
            if (HttpContext != null)
            {
                var authUser = _auth.GetIsLoggedIn(HttpContext);
                if (authUser == null)
                {
                    return false;
                }
                if (!_auth.IsAdmin(authUser.Id))
                {
                
                    ViewData["AuthUser"] = authUser;
                    return true;
                }
            }          
            return false;
        }       
        
        [HttpGet]
        public IActionResult ListUser()
        {
            if(RightCheck())
            {
                UserListViewModel viewModel = new UserListViewModel();
                viewModel.AllUsers = _userLogic.GetAll();
                return View(viewModel);
            };
            return RedirectToAction("Index", "Home");
        }
        
        [HttpGet]
        public IActionResult EditUser(int id)
        {
            if (RightCheck())
            {
                AdminUserEditViewModel viewModel = new AdminUserEditViewModel();
                        
                var user = _userLogic.GetBy(id);
                viewModel.Id = user.Id;
                viewModel.FirstName = user.Email;
                viewModel.LastName = user.LastName;
                viewModel.BirthDate = user.BirthDate;
                viewModel.Blocked = user.Blocked;
                viewModel.Length = user.Length;          
        
                viewModel.Rights = _rightLogic.GetAll().Select(a => new SelectListItem
                {
                    Text = a.Name,
                    Value = a.Id.ToString()
                });
            
                return View(viewModel);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}