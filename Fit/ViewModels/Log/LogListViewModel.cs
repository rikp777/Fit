using System.Collections;
using System.Collections.Generic;
using Fit.Models;
using Models;

namespace Fit.ViewModels.Log
{
    public class LogListViewModel
    {
        public IEnumerable<IFoodlog> FoodlogsBreakfast { get; set; }
        public IEnumerable<IFoodlog> FoodlogsLunch { get; set; }
        public IEnumerable<IFoodlog> FoodlogsSupper { get; set; }
        public IEnumerable<BMIViewModel> BMIs { get; set; }
        public IEnumerable<IGoalLog> GoalLogs { get; set; }
        public CaloriesOverViewModel CaloriesOverViewModel { get; set; }
    }
}