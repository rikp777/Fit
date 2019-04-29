using Models;

namespace Fit.Models
{
    public class Nutrient : INutrient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double MaxIntake { get; set; }
    }
}