using System;

namespace Models
{
    public interface IGoalLog
    {
        int Id { get; }
        int Calories { get; }
        DateTime DateTime { get; }
        IUser User { get; }
    }
}