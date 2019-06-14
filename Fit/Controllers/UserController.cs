using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using Data.Contexts.SQLContexts;
using Enum;
using Fit.Models;
using Fit.ViewModels.Auth;
using Fit.ViewModels.User;
using Logic;
using Logic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;

namespace Fit.Controllers
{
    public class UserController : Controller
    {
        private readonly UserLogic _userLogic;
        private readonly FoodlogLogic _foodlogLogic;
        private readonly RightLogic _rightLogic;
  

        public UserController(UserLogic userLogic, FoodlogLogic foodlogLogic, RightLogic rightLogic)
        {
            _userLogic = userLogic;
            _foodlogLogic = foodlogLogic;
            _rightLogic = rightLogic;
        }
        
        /// <summary>
        ///
        ///    Create In AuthController 
        /// 
        /// </summary>  
        
        
        
        
        /// <summary>
        ///
        ///    Read
        /// 
        /// </summary>        
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        
        /// <summary>
        ///
        ///    Update
        /// 
        /// </summary>       
        [Authorize]
        [HttpGet]
        public IActionResult Edit(int? id)
        {            
            //var userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value);
            var authUser = AuthController.GetAuthUser(User);
            var user = AuthController.GetAuthUser(User);
            
            if (User.IsInRole("Admin") && id != null)
            {
                //user = _userLogic.GetBy((int) (User.IsInRole("Admin") ? id : userId));
                user = _userLogic.GetBy(authUser.Id, (int) id);
            }


            var viewModel = new UserEditViewModel();
            if (user != null)
            {
                viewModel.Id = user.Id;
                viewModel.Email = user.Email;
                viewModel.FirstName = user.FirstName;
                viewModel.LastName = user.LastName;
                viewModel.BirthDate = user.BirthDate;
                viewModel.Length = user.Length;
                viewModel.Blocked = user.Blocked;
                viewModel.Rights = _rightLogic.GetAll().Select(a => new SelectListItem
                {
                    Text = a.Name,
                    Value = a.Id.ToString(),
                    Selected = a.Id == user.Right.Id
                });
            }
            else
            {
                viewModel = null;
            }

            return View(viewModel);       
        }
        [Authorize]
        [HttpPost]
        public IActionResult Edit(int? id, UserEditViewModel data)
        {
            var userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value);

            var user = _userLogic.GetBy(AuthController.GetAuthUserId(User), userId);

            if (User.IsInRole("Admin") && id != null)
            {
                user = _userLogic.GetBy(AuthController.GetAuthUserId(User), (int) id);
            }
            
            var userNew = new User
            {
                Id = user.Id,
                FirstName = data.FirstName,
                LastName = data.LastName,
                BirthDate = data.BirthDate,
                Length = data.Length,
                Email = data.Email,
                Blocked = user.Blocked,
                Right = user.Right
            };

            bool success;
            if (User.IsInRole("Admin"))
            {
                userNew.Right = _rightLogic.GetBy(data.RightId);
                userNew.Blocked = data.Blocked;
                success = _userLogic.Edit(userId, userNew); 
            }
            else
            {
                success = _userLogic.ChangeUser(userNew);
            }
                           
            return success ? RedirectToAction("List", "User") : RedirectToAction("Edit" , new { id = data.Id});
        }
        
        /// <summary>
        ///
        ///    Delete
        /// 
        /// </summary>
        [HttpGet]
        public IActionResult Delete(int id)
        {
            
            var success = _userLogic.Delete(AuthController.GetAuthUserId(User), id);
            return RedirectToAction("List");
        }
        
        
        /// <summary>
        ///
        ///    List
        ///     
        /// </summary>
        [HttpGet]
        public IActionResult List()
        {
            UserListViewModel viewModel = new UserListViewModel();
            viewModel.AllUsers = _userLogic.GetAll(AuthController.GetAuthUserId(User));
            return View(viewModel);
        }        
       
              
    }
}