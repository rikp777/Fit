using System;
using System.Collections.Generic;
using Fit.Models;
using Fit.ViewModels.Article;
using Fit.ViewModels.Auth;
using Microsoft.AspNetCore.Mvc;
using Logic;
using Microsoft.AspNetCore.Http;
using Models;

namespace Fit.Controllers
{
    public class HomeController : Controller
    {
        private readonly ArticleLogic _articleLogic;

        public HomeController(ArticleLogic articleLogic)
        {
            _articleLogic = articleLogic;
        }
        
        [HttpGet]
        public IActionResult Index()
        {        
            ArticleListViewModel viewModel = new ArticleListViewModel();
          
            viewModel.AllArticles = _articleLogic.GetAll();
            return View(viewModel);
        }
    }
}
