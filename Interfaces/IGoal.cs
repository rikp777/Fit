using System;

namespace Models
{
    public interface IGoal
    {
        int Id { get; }
        int Calories { get; }
        DateTime DateTime { get; }
        IUser User { get; }
    }
}