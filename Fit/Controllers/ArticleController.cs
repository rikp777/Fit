using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Claims;
using Fit.Models;
using Fit.ViewModels.Article;
using Fit.ViewModels.Auth;
using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using static System.Int32;

namespace Fit.Controllers
{
    public class ArticleController : Controller
    {
        private readonly ArticleLogic _articleLogic;
        private readonly NutrientLogic _nutrientLogic;

        public ArticleController(ArticleLogic articleLogic, NutrientLogic nutrientLogic)
        {
            _articleLogic = articleLogic;
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
            var viewModel = new ArticleAddViewModel
            {
                NutientsList = _nutrientLogic.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };

            return View(viewModel);
        }
        
        [Authorize(Roles = "Admin, Instructor")] 
        [HttpPost]
        public IActionResult Add(ArticleAddViewModel data)
        {
            var intakes = new List<INutrientIntake>();

            foreach (var id in data.NutrientIds)
            {
                intakes.Add(new NutrientIntake
                {
                    Nutrient = _nutrientLogic.GetBy(id),
                    Amount = 0,
                });
            }

            data.NutrientIntakes = intakes;

            return View(data);
            return RedirectToAction("List", "Article");
        }
        

            
        /// <summary>
        /// 
        ///     Update
        ///
        ///     Auth     = True 
        ///     right    = Admin
        /// 
        /// </summary>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View();
        }   
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Edit(ArticleEditViewModel data)
        {
//            _articleLogic.Delete(data.Id);
//            
            return RedirectToAction("List", "Article");
        }
        
        
        
        /// <summary>
        ///
        ///     Delete
        ///
        ///     Auth = True
        ///     Right = Admin
        /// 
        /// </summary>
        [HttpGet]
        public IActionResult Delete(int id)
        {
//            if(User.IsInRole("Admin"))
//            {
//                _articleLogic.Delete(id);
//            }
            return RedirectToAction("List", "Article");
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
            ArticleListViewModel viewModel = new ArticleListViewModel();
            viewModel.AllArticles = _articleLogic.GetAll() as List<IArticle>;
            return View(viewModel);  
        }        
    }
}