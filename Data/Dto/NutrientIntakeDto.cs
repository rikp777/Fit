using Models;

namespace Data.Dto
{
    public class NutrientIntakeDto : INutrientIntake
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public INutrient Nutrient { get; set; }
    }
}