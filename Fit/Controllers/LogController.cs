using System;
using System.Linq;
using Data.dto;
using Enum;
using Fit.Models;
using Fit.ViewModels.Log;
using Fit.ViewModels.User;
using Interfaces;
using Logic;
using Microsoft.AspNetCore.Mvc;

namespace Fit.Controllers
{
    public class LogController : Controller
    {
        private readonly FoodlogLogic _foodlogLogic = new FoodlogLogic();
        private readonly ArticleLogic _articleLogic = new ArticleLogic();
  
        private AuthController _auth = new AuthController();
        // GET
        [HttpGet]
        public IActionResult Index()
        {
            var authUser = _auth.GetAuth(HttpContext);
            ViewData["AuthUser"] = authUser;
            if (authUser != null)
            {
                LogListViewModel viewModel = new LogListViewModel();
                viewModel.FoodlogsBreakfast = _foodlogLogic.GetAllBy(authUser).Where(f => f.DateTime.Hour >= 1 && f.DateTime.Hour < 11);
                viewModel.FoodlogsLunch = _foodlogLogic.GetAllBy(authUser).Where(f => f.DateTime.Hour >= 11 && f.DateTime.Hour < 17);
                viewModel.FoodlogsSupper = _foodlogLogic.GetAllBy(authUser).Where(f => f.DateTime.Hour >= 17 && f.DateTime.Hour < 23);
                
                return View(viewModel);
            }
            return RedirectToAction("Login", "Auth");
        }
        
        [HttpPost]
        public IActionResult Add(LogViewModel data)
        {
            if (FoodLogViewModelToInterface(data) != null)
            {
                if (_foodlogLogic.Add(FoodLogViewModelToInterface(data)))
                {
                    return RedirectToAction("Index", "Log");
                }
            }
            
            return RedirectToAction("Index", "Log");
        }

        private IFoodlog FoodLogViewModelToInterface(LogViewModel viewModel)
        {
            if (Unit.TryParse(viewModel.Unit, out Unit unit))
            {
                IFoodlog foodlog = new Foodlog
                {
                    Amount = viewModel.Amount,
                    DateTime = viewModel.Date.Date + viewModel.Time.TimeOfDay,
                    User = _auth.GetAuth(HttpContext),
                    Unit = unit,
                    Article = _articleLogic.GetBy(viewModel.ArticleId)
                };
                return foodlog;
            }
            return null;
        }
    }
}