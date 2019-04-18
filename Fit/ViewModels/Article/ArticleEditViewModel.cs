using System.Collections.Generic;
using Models;

namespace Fit.ViewModels.Article
{
    public class ArticleEditViewModel : IArticle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Calories { get; set; }
        public IEnumerable<INutrientIntake> Nutrients { get; set; }
    }
}