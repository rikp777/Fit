using System;

namespace Models
{
    public interface INutrientIntake
    {
        double Amount { get; }
        INutrient Nutrient { get; }
    }
}