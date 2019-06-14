using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fit.ViewModels.Article
{
    public class ArticleEditNutrientIntakeViewModel
    {
        //public IEnumerable<SelectListItem> NutientsList { get; set; }
        public string Nutrient { get; set; }
        public int NutrientId { get; set; }
        public string Amount { get; set; }
        public int ArticleId { get; set; }
    }
}