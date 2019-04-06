using System.Collections.Generic;

namespace Interfaces
{
    public interface IArticle
    {
        int Id { get; set; }
        string Name { get; set; }
        int Calories { get; set; }
        IEnumerable<INutrientIntake> Nutrients { get; set; }
    }
}