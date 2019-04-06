using System;

namespace Interfaces
{
    public interface INutrientIntake
    {
        INutrient Nutrient { get; set; }
        Double Amount { get; set; }
    }
}