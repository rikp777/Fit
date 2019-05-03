using Models;

namespace Fit.Models
{
    public class NutrientIntake : INutrientIntake
    {
        public INutrient Nutrient { get; set; }
        public decimal Amount { get; set; }
    }
}