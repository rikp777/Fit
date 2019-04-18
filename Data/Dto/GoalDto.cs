using System;
using Models;

namespace Data.Dto
{
    public class GoalDto : IGoal
    {
        public int Id { get; set; }
        public int Calories { get; set; }
        public DateTime DateTime { get; set; }
        public IUser User { get; set; }
    }
}