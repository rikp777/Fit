using System;

namespace Models
{
    public interface INutrientIntake
    {
        decimal Amount { get; }
        INutrient Nutrient { get; }
    }
}