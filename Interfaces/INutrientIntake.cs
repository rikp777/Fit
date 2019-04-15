using System;

namespace Interfaces
{
    public interface INutrientIntake
    {
        INutrient Nutrient { get; }
        Double Amount { get; }
    }
}