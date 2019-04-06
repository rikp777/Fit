using Interfaces;

namespace Data.dto
{
    public class NutrientDto : INutrient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double MaxIntake { get; set; }
    }
}