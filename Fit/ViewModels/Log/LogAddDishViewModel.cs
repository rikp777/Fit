using System.Collections.Generic;
using Models;

namespace Fit.ViewModels.Log
{
    public class LogAddDishViewModel
    {
        public string DishName { get; set; }
        public string DishData { get; set; }
        public IEnumerable<IArticle> Articles { get; set; }
    }
}