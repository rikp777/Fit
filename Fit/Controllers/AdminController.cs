using System;
using System.Collections.Generic;
using System.Linq;
using Fit.ViewModels.Admin;
using Fit.ViewModels.Article;
using Fit.ViewModels.Auth;
using Fit.ViewModels.User;
using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fit.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {       
//        private readonly ArticleLogic _articleLogic = new ArticleLogic();
//        private readonly UserLogic _userLogic = new UserLogic();
//        private readonly RightLogic _rightLogic = new RightLogic();
//        private readonly AuthController _auth = new AuthController();       
//        
//
//        
//        [HttpGet]
//        public IActionResult EditUser(int id)
//        {
//
//                AdminUserEditViewModel viewModel = new AdminUserEditViewModel();
//                        
//                var user = _userLogic.GetBy(id);
//                viewModel.Id = user.Id;
//                viewModel.FirstName = user.Email;
//                viewModel.LastName = user.LastName;
//                viewModel.BirthDate = user.BirthDate;
//                viewModel.Blocked = user.Blocked;
//                viewModel.Length = user.Length;
//                viewModel.Right = user.Right.Id;
//        
//                viewModel.Rights = _rightLogic.GetAll().Select(a => new SelectListItem
//                {
//                    Text = a.Name,
//                    Value = a.Id.ToString(),
//                    Selected =  a.Id == user.Right.Id
//                });
//            
//                return View(viewModel);
//        }
//        [HttpPost]
//        public IActionResult EditUser(AdminUserEditViewModel data)
//        {
//
//                AdminUserEditViewModel viewModel = new AdminUserEditViewModel();
//                        
//                var user = _userLogic.GetBy(data.Id);
//                user.FirstName = data.FirstName;
//                user.LastName = data.LastName;
//                user.Blocked = data.Blocked;
//                user.BirthDate = data.BirthDate;
//                user.Length = data.Length;
//                user.Right = _rightLogic.GetBy(data.Right);
//                var right = _rightLogic.GetBy(data.Right);
//                var success = _userLogic.ChangeUser(user);
//                if(success){
//                    return RedirectToAction("List", "Lis");
//                }
//            
//                return View(viewModel);
//        }

    }
}