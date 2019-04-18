using System;

namespace Models
{
    public interface INutrientIntake
    {
        INutrient Nutrient { get; }
        Double Amount { get; }
    }
}