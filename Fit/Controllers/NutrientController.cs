using System;
using System.Linq;
using System.Security.Claims;
using Fit.Models;
using Fit.ViewModels.Article;
using Fit.ViewModels.Nutrient;
using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fit.Controllers
{
    public class NutrientController : Controller
    {
        private readonly NutrientLogic _nutrientLogic;

        public NutrientController(NutrientLogic nutrientLogic)
        {
            _nutrientLogic = nutrientLogic;         
        }
        
        
        /// <summary>
        /// 
        ///     Create
        ///
        ///     Auth     = True
        ///     Right    = Admin, Instructor
        /// 
        /// </summary>
        [Authorize(Roles = "Admin, Instructor")] 
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [Authorize(Roles = "Admin, Instructor")] 
        [HttpPost]
        public IActionResult Add(NutrientAddViewModel data)
        {
            var userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value);  
            
            
            var nutrient = new Nutrient
            {
                Id = 0,
                Name = data.Name,
                MaxIntake = data.MaxIntake,
            };
            
            
            if (_nutrientLogic.Add(userId, nutrient))
            {
                return RedirectToAction("List", "Nutrient");
            }
            
            
            ViewData["message"] = "Er ging iets fout";
            return View(data);
        }

        
        
        /// <summary>
        /// 
        ///     Update
        ///
        ///     Auth     = True 
        ///     right    = Admin, Instructor
        /// 
        /// </summary>
        [Authorize(Roles = "Admin, Instructor")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var nutrient = _nutrientLogic.GetBy(id);
            
            
            var viemodel = new NutrientEditViewModel
            {
                Name = nutrient.Name,
                MaxIntake = nutrient.MaxIntake
            };
            
            
            return View(viemodel);
        }   
        [Authorize(Roles = "Admin, Instructor")]
        [HttpPost]
        public IActionResult Edit(int id, NutrientEditViewModel data)
        {
            var userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value);  
            
            
            var nutrient = new Nutrient
            {
                Id = id,
                Name = data.Name,
                MaxIntake = data.MaxIntake
            };
            
            
            if (_nutrientLogic.Edit(userId, nutrient))
            {
                return RedirectToAction("List", "Nutrient");
            }
            
            
            ViewData["message"] = "Er ging iets fout";
            return View(data);
        }
        
        
        
        /// <summary>
        ///
        ///     Delete
        ///
        ///     Auth = True
        ///     Right = Admin, Instructor
        /// 
        /// </summary>
        [Authorize(Roles = "Admin, Instructor")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value);  
            
            
            _nutrientLogic.Delete(userId, id);
            
            
            return RedirectToAction("List", "Nutrient");
        }
        
        
        
        /// <summary>
        ///
        ///     List
        ///
        ///     Auth     = False
        /// 
        /// </summary>
        public IActionResult List()
        {
            var viewModel = new NutrientListViewModel();
            var nutrients = _nutrientLogic.GetAll();

            viewModel.AllNutrients = nutrients;
            return View(viewModel);  
        }
    }
}