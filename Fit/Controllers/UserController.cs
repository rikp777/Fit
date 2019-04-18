using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Data.Contexts.SQLContexts;
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
            UserEditViewModel viewModel = new UserEditViewModel();           
    
            var user = _userLogic.GetBy(id);
            viewModel.Id = user.Id;
            viewModel.Email = user.Email;
            viewModel.FirstName = user.Email;
            viewModel.LastName = user.LastName;
            viewModel.BirthDate = user.BirthDate;
            viewModel.Length = user.Length;
            viewModel.Right = user.Right;
    
            return View(viewModel);       
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