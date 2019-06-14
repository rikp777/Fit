using System;
using System.Linq;
using Fit.Models;
using Fit.ViewModels.Article;
using Fit.ViewModels.Dish;
using Fit.ViewModels.Log;
using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Fit.Controllers
{
    public class DishController : Controller
    {
        private readonly DishLogic _dishLogic;
        private readonly ArticleLogic _articleLogic;
        private readonly NutrientLogic _nutrientLogic;

        public DishController(DishLogic dishLogic, ArticleLogic articleLogic, NutrientLogic nutrientLogic)
        {
            _dishLogic = dishLogic;
            _articleLogic = articleLogic;
            _nutrientLogic = nutrientLogic;         
        }
        
        
        
        
        
        /// <summary>
        ///
        ///     Create Dish
        ///
        ///     Auth     = True
        ///     Right    = Admin, Instructor 
        /// 
        /// </summary>
        [Authorize(Roles = "Admin, Instructor")] 
        [HttpPost]
        public IActionResult Add(LogAddDishViewModel data)
        {
            if (DishViewmodelToInterface(data) != null)
            {
                if (_dishLogic.Add(AuthController.GetAuthUserId(User), DishViewmodelToInterface(data)))
                {
                    return RedirectToAction("List", "Article");
                }
            }
            return RedirectToAction("List", "Article");
        }
        
        
        /// <summary>
        ///
        ///     Create Dish
        ///
        ///     Auth     = True
        ///     Right    = Admin, Instructor 
        /// 
        /// </summary>
        [Authorize(Roles = "Admin, Instructor")] 
        [HttpPost]
        public IActionResult Edit(LogAddDishViewModel data)
        {
            if (DishViewmodelToInterface(data) != null)
            {
                if (_dishLogic.Add(AuthController.GetAuthUserId(User), DishViewmodelToInterface(data)))
                {
                    return RedirectToAction("List", "Article");
                }
            }
            return RedirectToAction("List", "Article");
        }
        
        
        /// <summary>
        ///
        ///     Create Dish
        ///
        ///     Auth     = True
        ///     Right    = Admin, Instructor 
        /// 
        /// </summary>
        [Authorize(Roles = "Admin, Instructor")] 
        [HttpPost]
        public IActionResult Delete(LogAddDishViewModel data)
        {
            if (DishViewmodelToInterface(data) != null)
            {
                if (_dishLogic.Add(AuthController.GetAuthUserId(User), DishViewmodelToInterface(data)))
                {
                    return RedirectToAction("List", "Article");
                }
            }
            return RedirectToAction("List", "Article");
        }
        
        
        
        
        
        
        
        // Remaps 
        // TODO make generic object remap
        private IDish DishViewmodelToInterface(LogAddDishViewModel viewModel)
        {
            var dishes = viewModel.DishData.Split(',');

            var articleDishes = (from dish in dishes
                    select dish.Split(':')
                    into values
                    let article = _articleLogic.GetBy(Convert.ToInt16(values.First()))
                    select new ArticleDish
                    {
                        Amount = Convert.ToInt16(values.Last()),
                        Article = article,
                    }).Cast<IArticleDish>()
                .ToList();

            var dishNew = new Dish
            {
                Name = viewModel.DishName,
                ArticleDishes = articleDishes
            };
            return dishNew;
        }
    }
}