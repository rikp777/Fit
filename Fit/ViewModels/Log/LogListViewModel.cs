using System.Collections.Generic;
using Models;

namespace Fit.ViewModels.Log
{
    public class LogListViewModel
    {
        public IEnumerable<IFoodlog> FoodlogsBreakfast { get; set; }
        public IEnumerable<IFoodlog> FoodlogsLunch { get; set; }
        public IEnumerable<IFoodlog> FoodlogsSupper { get; set; }
    }
}