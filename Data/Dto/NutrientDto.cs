using Models;

namespace Data.Dto
{
    public class NutrientDto : INutrient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal MaxIntake { get; set; }
    }
}