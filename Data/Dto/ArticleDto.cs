using System.Collections.Generic;
using Interfaces;

namespace Data.dto
{
    public class ArticleDto : IArticle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Calories { get; set; }
        public IEnumerable<INutrientIntake> Nutrients { get; set; }
    }
}