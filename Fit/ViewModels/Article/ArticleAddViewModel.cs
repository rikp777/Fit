using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;

namespace Fit.ViewModels.Article
{
    public class ArticleAddViewModel
    {
        public string Name { get; set; }
        public int Calories { get; set; }
        public IEnumerable<INutrientIntake> NutrientIntakes { get; set; }
        public List<int> NutrientIds { get; set; }
        public IEnumerable<SelectListItem> NutientsList { get; set; }
    }
}