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
        public IActionResult Add(ArticleAddViewModel data)
        {

            
            
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
            return null;
        }   
        [Authorize(Roles = "Admin, Instructor")]
        [HttpPost]
        public IActionResult Edit(int id, ArticleEditViewModel data)
        {
            return null;
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
            return null;
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