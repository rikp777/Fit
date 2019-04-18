using Models;

namespace Data.Dto
{
    public class NutrientIntakeDto : INutrientIntake
    {
        public INutrient Nutrient { get; set; }
        public double Amount { get; set; }
    }
}