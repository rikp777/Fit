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
//            var viewModel = new ArticleAddViewModel
//            {
//                NutientsList = _nutrientLogic.GetAll().Select(i => new SelectListItem
//                {
//                    Text = i.Name,
//                    Value = i.Id.ToString()
//                })
//            };

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
            
            var userId = Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value);  
            
            
            var article = new Article
            {
                Id = 0,
                Name = data.Name,
                Calories = data.Calories,
                NutrientIntakes = null
            };
            
            
            if (_articleLogic.Add(userId, article))
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
            int userId = Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value);

            
            var article = new Article
            {
                Id = id,
                Calories = data.Calories,
                Name = data.Name,
            };
                
                
            if(_articleLogic.Edit(userId, article))
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
            int userId = Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value);  
            
            
            if (!_articleLogic.Delete(userId, id))
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
            var viewModel = new ArticleListViewModel();
            var articleList = _articleLogic.GetAll();

            viewModel.AllArticles = articleList;
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
            var userId = Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value);
                       

            var nutrientIntake = new NutrientIntake
            {
                Amount = data.Amount,
                Nutrient = _nutrientLogic.GetBy(data.NutrientId),
            };
                
                
            if(_articleLogic.AddNutrientIntake(userId, id, nutrientIntake))
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
            var nutrients = _nutrientLogic.GetAll();         
            var result = nutrients.Where(a => articles.NutrientIntakes.All(n => n.Nutrient.Name != a.Name));

            var list = new List<SelectListItem>();
            list.AddRange(result.Select(i => new SelectListItem
            {
                Disabled = false,
                Text = i.Name,
                Value = i.Id.ToString(),  
                Selected = false,
            }));
            list.Add(new SelectListItem
            {
                Disabled = false,
                Text = articleNutrient.Nutrient.Name,
                Value = articleNutrient.Nutrient.Id.ToString(),
                Selected = true
            });
            var viewModel = new ArticleEditNutrientIntakeViewModel
            {
                NutientsList = list
            };
            viewModel.ArticleId = articleId;
            viewModel.NutrientId = articleNutrient.Nutrient.Id;
            viewModel.Amount = articleNutrient.Amount.ToString();
            
            
            return View(viewModel);
        }

        [Authorize(Roles = "Admin, Instructor")]
        [HttpPost]
        public IActionResult EditNutrientIntake(int articleId, ArticleEditNutrientIntakeViewModel data)
        {          
            var userId = Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value);
            if (!double.TryParse(data.Amount, out var amount))
            {
                return RedirectToAction("EditNutrientIntake", "Article", new { articleId = data.ArticleId, nutrientId = data.NutrientId});     
            }           

            var nutrientIntake = new NutrientIntake
            {
                Amount = amount,
                Nutrient = _nutrientLogic.GetBy(data.NutrientId),
            };
                
                
            if(_articleLogic.EditNutrientIntake(userId, data.ArticleId, nutrientIntake))
            {
                return RedirectToAction("List", "Article");
            }
            

            ViewData["message"] = "Er ging iets fout tijdens het wijzigen";
            return RedirectToAction("EditNutrientIntake", "Article", new { articleId = data.ArticleId, nutrientId = data.NutrientId});
        }

        [Authorize(Roles = "Admin, Instructor")]
        [HttpGet]
        public IActionResult DeleteNutrientIntake(int articleId, int nutrientId)
        {
            var userId = Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value);
            
            
            var nutrientIntake = new NutrientIntake
            {
                Nutrient = _nutrientLogic.GetBy(nutrientId),
            };
            
            
            _articleLogic.DeleteNutrientIntake(userId, articleId, nutrientIntake);
            
            
            return RedirectToAction("List", "Article");
        }
    }
}