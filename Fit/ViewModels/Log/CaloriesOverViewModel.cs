using Models;

namespace Fit.ViewModels.Log
{
    public class CaloriesOverViewModel
    {
        public int ConsumedCalories { get; set; }
        public IGoalLog GoalLog { get; set; }
        public int CaloriesOver { get; set; }
    }
}