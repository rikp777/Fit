using System.Collections.Generic;
using Models;

namespace Data.Dto
{
    public class ArticleDishDto : IArticleDish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Calories { get; set; }
        public int Amount { get; set; }
        public IEnumerable<INutrientIntake> NutrientIntakes { get; set; }

    }
}