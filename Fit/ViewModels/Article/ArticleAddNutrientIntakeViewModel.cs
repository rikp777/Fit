using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;

namespace Fit.ViewModels.Article
{
    public class ArticleAddNutrientIntakeViewModel
    {
        public IEnumerable<SelectListItem> NutientsList { get; set; }
        public int NutrientId { get; set; }
        public decimal Amount { get; set; }
    }
}