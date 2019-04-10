using System;
using System.Collections.Generic;
using System.Linq;
using Fit.ViewModels.Admin;
using Fit.ViewModels.Article;
using Fit.ViewModels.Auth;
using Fit.ViewModels.User;
using Interfaces;
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
                if (_auth.CheckAuth(HttpContext, "Admin"))
                {
                    var authUser = _auth.GetAuth(HttpContext);
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
                viewModel.Right = user.Right.Id;
        
                viewModel.Rights = _rightLogic.GetAll().Select(a => new SelectListItem
                {
                    Text = a.Name,
                    Value = a.Id.ToString(),
                    Selected =  a.Id == user.Right.Id
                });
            
                return View(viewModel);
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult EditUser(AdminUserEditViewModel data)
        {
            if (RightCheck())
            {
                AdminUserEditViewModel viewModel = new AdminUserEditViewModel();
                        
                var user = _userLogic.GetBy(data.Id);
                user.FirstName = data.FirstName;
                user.LastName = data.LastName;
                user.Blocked = data.Blocked;
                user.BirthDate = data.BirthDate;
                user.Length = data.Length;
                user.Right = _rightLogic.GetBy(data.Right);
                var right = _rightLogic.GetBy(data.Right);
                var success = _userLogic.ChangeUser(user);
                if(success){
                    return RedirectToAction("ListUser", "Admin");
                }
            
                return View(viewModel);
            }
            return RedirectToAction("Index", "Home");
        }
        
        [HttpGet]
        public IActionResult DeleteUser(int id)
        {
            var success = _userLogic.Delete(id);
            return RedirectToAction("ListUser");
        }
    }
}