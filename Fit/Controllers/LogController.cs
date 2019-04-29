using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Enum;
using Fit.Models;
using Fit.ViewModels.Article;
using Fit.ViewModels.Log;
using Fit.ViewModels.User;
using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Fit.Controllers
{
    public class LogController : Controller
    {
        private readonly FoodlogLogic _foodlogLogic;
        private readonly ArticleLogic _articleLogic;
        private readonly UserLogic _userLogic;

        public LogController(FoodlogLogic foodlogLogic, ArticleLogic articleLogic, UserLogic userLogic)
        {
            _foodlogLogic = foodlogLogic;
            _articleLogic = articleLogic;
            _userLogic = userLogic;
        }
        
        /// <summary>
        ///
        ///     Create
        ///
        ///     Auth     = True
        ///     Right    = All
        /// 
        /// </summary>
        [Authorize]
        [HttpGet]
        public IActionResult Add()
        {
            var viewModel = new ArticleListViewModel();
            viewModel.AllArticles = (List<IArticle>) _articleLogic.GetAll();
            
            return View(viewModel);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Add(LogAddViewModel data)
        {
//            if (FoodLogViewModelToInterface(data) != null)
//            {
//                if (_foodlogLogic.Add(FoodLogViewModelToInterface(data)))
//                {
//                    return RedirectToAction(nameof(Index));
//                }
//            }            
            return RedirectToAction("Index");
        }
        
        
        
        /// <summary>
        ///
        ///     Read
        /// 
        /// </summary>
        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            int userId = Int32.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value);
            var authUser = _userLogic.GetBy(userId);
            
            var foodlogs = new List<Foodlog>();

            foreach (var foodlog in _foodlogLogic.GetAllBy(authUser))
            {
                var newFoodlog = new Foodlog
                {
                    Id = foodlog.Id,
                    Amount = foodlog.Amount,
                    Article = new Article
                    {
                        NutrientIntakes = null
                    }
                };
                foodlogs.Add(newFoodlog);
            }


            
            LogListViewModel viewModel = new LogListViewModel();
            viewModel.FoodlogsBreakfast = foodlogs;
//            viewModel.FoodlogsBreakfast = _foodlogLogic.GetAllBy(authUser).Where(f => f.DateTime.Hour >= 1 && f.DateTime.Hour < 11);
//            viewModel.FoodlogsLunch = _foodlogLogic.GetAllBy(authUser).Where(f => f.DateTime.Hour >= 11 && f.DateTime.Hour < 17);
//            viewModel.FoodlogsSupper = _foodlogLogic.GetAllBy(authUser).Where(f => f.DateTime.Hour >= 17 && f.DateTime.Hour < 23);
            
            return View(viewModel);
        }
        
       

        
        
        
        // TODO make generic object remap
        private IFoodlog FoodLogViewModelToInterface(LogAddViewModel viewModel)
        {
//            if (Unit.TryParse(viewModel.Unit, out Unit unit))
//            {
//                int userId = Int32.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value);
//                var authUser = _userLogic.GetBy(userId);
//                IFoodlog foodlog = new Foodlog
//                {
//                    Amount = viewModel.Amount,
//                    DateTime = viewModel.Date.Date + viewModel.Time.TimeOfDay,
//                    User = authUser,
//                    Unit = unit,
//                    Article = _articleLogic.GetBy(viewModel.ArticleId)
//                };
//                return foodlog;
//            }
            return null;
        }
    }
}