using System;
using Models;

namespace Fit.Models
{
    public class GoalLog : IGoalLog
    {
        public int Id { get; set; }
        public int Calories { get; set; }
        public DateTime DateTime { get; set; }
        public IUser User { get; set; }
    }
}