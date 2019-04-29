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
        public IActionResult Edit(int id)
        {            
            var userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value);
            
            var user = _userLogic.GetBy(User.IsInRole("Admin") ? id : userId);

            var viewModel = new UserEditViewModel
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.Email,
                LastName = user.LastName,
                BirthDate = user.BirthDate,
                Length = user.Length,
                Rights = _rightLogic.GetAll().Select(a => new SelectListItem
                {
                    Text = a.Name, 
                    Value = a.Id.ToString(), 
                    Selected = a.Id == user.Right.Id
                })
            };



            return View(viewModel);       
        }
        [Authorize]
        [HttpPost]
        public IActionResult Edit(int id, UserEditViewModel data)
        {
            var userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value);
            var authUser = _userLogic.GetBy(data.Id);
            
            var oldUser = _userLogic.GetBy(id);
            var user = new User
            {
                Id = 0,
                FirstName = data.FirstName,
                LastName = data.LastName,
                BirthDate = data.BirthDate,
                Length = data.Length,
                Email = data.Email,
                Blocked = oldUser.Blocked,
                Right = oldUser.Right,
            };

            bool success;
            if (authUser.Right.Name == Right.Admin.ToString())
            {
                user.Right = _rightLogic.GetBy(data.Right);
                user.Blocked = data.Blocked;
                success = _userLogic.Edit(userId, user); 
            }
            else
            {
                success = _userLogic.ChangeUser(user);
            }
                           
            if (success)
            {
                return RedirectToAction("index", "Home");
            }
            
            return RedirectToAction("Edit" , new { id = data.Id});
        }
        
        /// <summary>
        ///
        ///    Delete
        /// 
        /// </summary>
        [HttpGet]
        public IActionResult Delete(int id)
        {
            
            var success = _userLogic.Delete(id);
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
            viewModel.AllUsers = _userLogic.GetAll();
            return View(viewModel);
        }        
       
              
    }
}