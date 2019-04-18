using System.Collections.Generic;
using System.Net;
using System.Runtime.InteropServices;
using Fit.ViewModels.Article;
using Fit.ViewModels.Auth;
using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Fit.Controllers
{
    public class ArticleController : Controller
    {
        private readonly ArticleLogic _articleLogic; 

        public ArticleController(ArticleLogic articleLogic)
        {
            _articleLogic = articleLogic;
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
        
        [Authorize(Roles = "Admin, Instructor")] 
        [HttpPost]
        public IActionResult Add(ArticleAddViewModel data)
        {
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
            _articleLogic.Delete(data.Id);
            
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
            if(User.IsInRole("Admin"))
            {
                _articleLogic.Delete(id);
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
            ArticleListViewModel viewModel = new ArticleListViewModel();
            viewModel.AllArticles = _articleLogic.GetAll() as List<IArticle>;
            return View(viewModel);  
        }        
    }
}