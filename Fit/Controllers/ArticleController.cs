using System.Collections.Generic;
using Fit.ViewModels.Article;
using Interfaces;
using Logic;
using Microsoft.AspNetCore.Mvc;

namespace Fit.Controllers
{
    public class ArticleController : Controller
    {
        private readonly ArticleLogic _articleLogic = new ArticleLogic();
        private readonly AuthController _auth = new AuthController();
        // GET
        public IActionResult List()
        {
            var authUser = _auth.GetAuth(HttpContext);
            ViewData["AuthUser"] = authUser;
            
            ArticleListViewModel viewModel = new ArticleListViewModel();
            viewModel.AllArticles = _articleLogic.GetAll() as List<IArticle>;
            return View(viewModel);
        }
    }
}