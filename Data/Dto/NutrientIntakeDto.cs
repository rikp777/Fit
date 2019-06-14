using Models;

namespace Data.Dto
{
    public class NutrientIntakeDto : INutrientIntake
    {
        public decimal Amount { get; set; }
        public INutrient Nutrient { get; set; }
    }
}