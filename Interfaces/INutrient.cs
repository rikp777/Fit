
namespace Interfaces
{
    public interface INutrient
    {
        int Id { get; set; }
        string Name { get; set; }
        double MaxIntake { get; set; }
    }
}