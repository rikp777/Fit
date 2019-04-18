using System.Collections.Generic;

namespace Models
{
    public interface IArticle
    {
        int Id { get;}
        string Name { get; }
        int Calories { get; }
        IEnumerable<INutrientIntake> Nutrients { get; }
    }
}