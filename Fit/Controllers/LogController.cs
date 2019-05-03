using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Claims;
using System.Xml.Linq;
using Enum;
using Fit.Models;
using Fit.ViewModels.Article;
using Fit.ViewModels.Log;
using Fit.ViewModels.User;
using Helpers;
using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Fit.Controllers
{
    public class LogController : Controller
    {
        private readonly DishLogic _dishLogic;
        private readonly GoalLogLogic _goalLogLogic;
        private readonly WeightLogLogic _weightLogLogic;
        private readonly FoodlogLogic _foodlogLogic;
        private readonly ArticleLogic _articleLogic;
        private readonly UserLogic _userLogic;

        public LogController(DishLogic dishLogic, GoalLogLogic goalLogLogic, FoodlogLogic foodlogLogic, WeightLogLogic weightLogLogic, ArticleLogic articleLogic, UserLogic userLogic)
        {
            _dishLogic = dishLogic;
            _goalLogLogic = goalLogLogic;
            _foodlogLogic = foodlogLogic;
            _weightLogLogic = weightLogLogic;
            _articleLogic = articleLogic;
            _userLogic = userLogic;
        }
        
        
        
        
        
        /// <summary>
        ///
        ///     Create Foodlog
        ///
        ///     Auth     = True
        ///     Right    = All
        /// 
        /// </summary>
        [Authorize]
        [HttpGet]
        public IActionResult AddFoodlog()
        {
            var viewModel = new ArticleListViewModel
            {
                AllArticles = _articleLogic.GetAll() as List<IArticle>
            };

            return View(viewModel);
        }
        [Authorize]
        [HttpPost]
        public IActionResult AddFoodlog(LogAddFoodlogViewModel data)
        {
            if (FoodLogViewModelToInterface(data) != null)
            {
                if (_foodlogLogic.Add(AuthController.GetAuthUserId(User), FoodLogViewModelToInterface(data)))
                {
                    return RedirectToAction("Index");
                }
            }            
            return RedirectToAction("Index");
        }
        
          
        
        
        

        
        
        
        
        
        /// <summary>
        ///
        ///     Create Weightlog
        ///
        ///     Auth     = True
        ///     Right    = All
        /// 
        /// </summary>
        [Authorize]
        [HttpGet]
        public IActionResult AddWeightlog()
        {       
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult AddWeightlog(LogAddWeightLogViewModel data)
        {
            if (_weightLogLogic.Add(AuthController.GetAuthUserId(User), WeightLogViewModelToInterface(data)))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
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
        public IActionResult AddGoalLog()
        {       
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult AddGoalLog(LogAddGoalLogViewModel data)
        {
            if (GoalLogViewModelToInterface(data) != null)
            {
                if (_goalLogLogic.Add(AuthController.GetAuthUserId(User), GoalLogViewModelToInterface(data)))
                {
                    return RedirectToAction("Index");
                }
            }            
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
            var authUser = AuthController.GetAuthUser(User);
            
            var bmis = _weightLogLogic
                .GetAllBy(authUser)
                .Select(weightlog => new BMIViewModel
                {
                    BMI = Math.Round((weightlog.Weight / (authUser.Length * authUser.Length / 10000)), 2, MidpointRounding.AwayFromZero), 
                    Lenght = authUser.Length, 
                    Weight = weightlog.Weight, 
                    DateTime = weightlog.DateTime
                }).ToList();

            CaloriesOverViewModel caloriesOverViewModel = null;
//            var num = _foodlogLogic.GetAllBy(authUser).Aggregate(0, (current, foodlog) => current + foodlog.Article.Calories);
//            if (_goalLogLogic.GetLastBy(authUser) != null && _foodlogLogic.GetAllBy(authUser) != null)
//            {
//                caloriesOverViewModel.ConsumedCalories = num;
//                caloriesOverViewModel.GoalLog = _goalLogLogic.GetLastBy(authUser);
//                caloriesOverViewModel.CaloriesOver = _foodlogLogic.GetAllBy(authUser).Aggregate(0,(current, foodlog) => current + foodlog.Article.Calories) - _goalLogLogic.GetLastBy(authUser).Calories;
//            }   

            var viewModel = new LogListViewModel
            {
                FoodlogsBreakfast = _foodlogLogic
                    .GetAllBy(authUser)
                    .Where(f => f.DateTime.Hour >= 1 && f.DateTime.Hour < 11),
                
                FoodlogsLunch = _foodlogLogic
                    .GetAllBy(authUser)
                    .Where(f => f.DateTime.Hour >= 11 && f.DateTime.Hour < 17),
                
                FoodlogsSupper = _foodlogLogic
                    .GetAllBy(authUser)
                    .Where(f => f.DateTime.Hour >= 17 && f.DateTime.Hour < 23),
                
                BMIs = bmis,
                
                GoalLogs = _goalLogLogic.GetAllBy(authUser),
                
                CaloriesOverViewModel = caloriesOverViewModel
            };

            return View(viewModel);
        }
        
       

        
        private IGoalLog GoalLogViewModelToInterface(LogAddGoalLogViewModel viewModel)
        {
            var goalLog = new GoalLog
            {
                DateTime = DateTime.Now,
                User = _userLogic.GetBy(AuthController.GetAuthUserId(User)),
                Calories = viewModel.Calories
            };
            return goalLog;
        }
        private IFoodlog FoodLogViewModelToInterface(LogAddFoodlogViewModel viewModel)
        {
            if (!Unit.TryParse(viewModel.Unit, out Unit unit)) return null;
            
            var foodlog = new Foodlog
            {
                Amount = viewModel.Amount,
                DateTime = viewModel.Date.Date + viewModel.Time.TimeOfDay,
                User = _userLogic.GetBy(AuthController.GetAuthUserId(User)),
                Unit = unit,
                Article = _articleLogic.GetBy(viewModel.ArticleId)
            };
            return foodlog;
        }
        private IWeightlog WeightLogViewModelToInterface(LogAddWeightLogViewModel viewmodel)
        {
            var weightLog = new WeightLog
            {
                DateTime = DateTime.Now,
                User = _userLogic.GetBy(AuthController.GetAuthUserId(User)),
                Weight = viewmodel.Weight
            };
            return weightLog;
        }
    }
}