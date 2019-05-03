
namespace Models
{
    public interface INutrient
    {
        int Id { get; }
        string Name { get; }
        decimal  MaxIntake { get; }
    }
}