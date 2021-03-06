using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.OleDb;
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
        private readonly DishLogic _dishLogic;
        private readonly ArticleLogic _articleLogic;
        private readonly NutrientLogic _nutrientLogic;

        public ArticleController(DishLogic dishLogic, ArticleLogic articleLogic, NutrientLogic nutrientLogic)
        {
            _dishLogic = dishLogic;
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
            return View(new ArticleAddViewModel());
        }     
        /// <summary>
        /// Note
        /// Handling Arrays of HTML Input Elements ASP.NET Wire Format for Model Binding to Arrays, Lists, Collections, Dictionaries not possible
        /// </summary>
        [Authorize(Roles = "Admin, Instructor")] 
        [HttpPost]
        public IActionResult Add(ArticleAddViewModel data)
        {                    
            var article = new Article
            {
                Id = 0,
                Name = data.Name,
                Calories = data.Calories,
                NutrientIntakes = null
            };          
            
            if (_articleLogic.Add(AuthController.GetAuthUserId(User), article))
            {
                return RedirectToAction("List", "Article");
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
            var oldArticle = _articleLogic.GetBy(id);           
            
            var viewmodel = new ArticleEditViewModel
            {
                Calories = oldArticle.Calories,
                Name = oldArticle.Name
            };          
            
            return View(viewmodel);
        }   
        [Authorize(Roles = "Admin, Instructor")]
        [HttpPost]
        public IActionResult Edit(int id, ArticleEditViewModel data)
        {       
            var article = new Article
            {
                Id = id,
                Calories = data.Calories,
                Name = data.Name,
            };              
                
            if(_articleLogic.Edit(AuthController.GetAuthUserId(User), article))
            {
                return RedirectToAction("List", "Article");
            }

            ViewData["message"] = "Er ging iets fout tijdens het wijzigen";
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
            if (!_articleLogic.Delete(AuthController.GetAuthUserId(User), id))
            {
                ViewData["message"] = "Er ging iets fout tijdens het verwijderen";
            }          
            
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
            var viewModel = new ArticleListViewModel
            {
                AllArticles = _articleLogic.GetAll(), 
                AllDishes = _dishLogic.GetAll()
            };

            return View(viewModel);  
        }

        
        
        
        
        /// <summary>
        ///
        ///     Add NutrientIntake for Article
        ///
        ///     Auth = True
        ///     Right = Admin, Instructor
        /// 
        /// </summary>
        [Authorize(Roles = "Admin, Instructor")]
        [HttpGet]
        public IActionResult AddNutrientIntake(int id)
        {
            var article = _articleLogic.GetBy(id);
            var nutrients = _nutrientLogic.GetAll();
            var result = nutrients;
            if (article.NutrientIntakes != null)
            {
                result = nutrients.Where(a => article.NutrientIntakes.All(n => n.Nutrient.Name != a.Name));
            }       
                         
            var viewModel = new ArticleAddNutrientIntakeViewModel
            {
                NutientsList = result.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })       
            };
            
            return View(viewModel);
        }
        [Authorize(Roles = "Admin, Instructor")]
        [HttpPost]
        public IActionResult AddNutrientIntake(int id, ArticleAddNutrientIntakeViewModel data)
        {
            var nutrientIntake = new NutrientIntake
            {
                Amount = data.Amount,
                Nutrient = _nutrientLogic.GetBy(data.NutrientId),
            }; 
                
            if(_articleLogic.AddNutrientIntake(AuthController.GetAuthUserId(User), id, nutrientIntake))
            {
                return RedirectToAction("List", "Article");
            }
            ViewData["message"] = "Er ging iets fout tijdens het wijzigen";
            return RedirectToAction("AddNutrientIntake", "Article");
        }
           
        
        
        
        
        /// <summary>
        ///
        ///     Edit NutrientIntake for Article
        ///
        ///     Auth = True
        ///     Right = Admin, Instructor
        /// 
        /// </summary>
        [Authorize(Roles = "Admin, Instructor")]
        [HttpGet]
        public IActionResult EditNutrientIntake(int articleId, int nutrientId)
        {
            var articleNutrient = _articleLogic.GetBy(articleId).NutrientIntakes.First(n => n.Nutrient.Id == nutrientId);
            var articles = _articleLogic.GetBy(articleId);
//            var nutrients = _nutrientLogic.GetAll();         
//            var result = nutrients.Where(a => articles.NutrientIntakes.All(n => n.Nutrient.Name != a.Name));
//
//            var list = new List<SelectListItem>();
//            list.AddRange(result.Select(i => new SelectListItem
//            {
//                Disabled = false,
//                Text = i.Name,
//                Value = i.Id.ToString(),  
//                Selected = false,
//            }));
//            list.Add(new SelectListItem
//            {
//                Disabled = false,
//                Text = articleNutrient.Nutrient.Name,
//                Value = articleNutrient.Nutrient.Id.ToString(),
//                Selected = true
//            });
//            var viewModel = new ArticleEditNutrientIntakeViewModel
//            {
//                NutientsList = list
//            };
//            viewModel.ArticleId = articleId;
//            viewModel.NutrientId = articleNutrient.Nutrient.Id;
//            viewModel.Amount = articleNutrient.Amount.ToString();
            var viewModel = new ArticleEditNutrientIntakeViewModel
            {
                Nutrient = articleNutrient.Nutrient.Name,
                Amount = articleNutrient.Amount.ToString(),
                ArticleId = articleId,
                NutrientId = articleNutrient.Nutrient.Id
            };
            
            return View(viewModel);
        }
        [Authorize(Roles = "Admin, Instructor")]
        [HttpPost]
        public IActionResult EditNutrientIntake(int articleId, ArticleEditNutrientIntakeViewModel data)
        {          
            if (!decimal.TryParse(data.Amount, out var amount))
            {
                return RedirectToAction("EditNutrientIntake", "Article", new { articleId = data.ArticleId, nutrientId = data.NutrientId});     
            }           

            var nutrientIntake = new NutrientIntake
            {
                Amount = amount,
                Nutrient = _nutrientLogic.GetBy(data.NutrientId),
            };        
                
            if(_articleLogic.EditNutrientIntake(AuthController.GetAuthUserId(User), data.ArticleId, nutrientIntake))
            {
                return RedirectToAction("List", "Article");
            }

            ViewData["message"] = "Er ging iets fout tijdens het wijzigen";
            return RedirectToAction("EditNutrientIntake", "Article", new { articleId = data.ArticleId, nutrientId = data.NutrientId});
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
        public IActionResult DeleteNutrientIntake(int articleId, int nutrientId)
        {    
            var nutrientIntake = new NutrientIntake
            {
                Nutrient = _nutrientLogic.GetBy(nutrientId),
            };         
            
            _articleLogic.DeleteNutrientIntake(AuthController.GetAuthUserId(User), articleId, nutrientIntake);
            
            return RedirectToAction("List", "Article");
        }
    }
}