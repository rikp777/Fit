using System.Collections.Generic;
using Models;

namespace Data.Dto
{
    public class ArticleDto : IArticle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Calories { get; set; }
        public IEnumerable<INutrientIntake> NutrientIntakes { get; set; }
    }
}