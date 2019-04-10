﻿using System;
using System.Collections.Generic;
using Fit.ViewModels.Article;
using Fit.ViewModels.Auth;
using Microsoft.AspNetCore.Mvc;
using Interfaces;
using Logic;
using Microsoft.AspNetCore.Http;

namespace Fit.Controllers
{
    public class HomeController : Controller
    {
        private UserLogic _userLogic = new UserLogic();
        private AuthController _auth = new AuthController();
        private readonly ArticleLogic _articleLogic = new ArticleLogic();
        
        [HttpGet]
        public IActionResult Index()
        {
            ViewData["AuthUser"] = _auth.GetAuth(HttpContext);
            
            ArticleListViewModel viewModel = new ArticleListViewModel();
            viewModel.AllArticles = _articleLogic.GetAll() as List<IArticle>;
            return View(viewModel);
        }
    }
}
