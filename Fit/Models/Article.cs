using System.Collections.Generic;
using Models;

namespace Fit.Models
{
    public class Article : IArticle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Calories { get; set; }
        public IEnumerable<INutrientIntake> NutrientIntakes { get; set; }
    }
}