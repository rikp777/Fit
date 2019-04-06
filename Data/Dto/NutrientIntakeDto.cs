using Interfaces;

namespace Data.dto
{
    public class NutrientIntakeDto : INutrientIntake
    {
        public INutrient Nutrient { get; set; }
        public double Amount { get; set; }
    }
}