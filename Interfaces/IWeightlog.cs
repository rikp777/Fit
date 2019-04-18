using System;

namespace Models
{
    public interface IWeightlog
    {
        int Id { get; }
        DateTime DateTime { get; }
        double Weight { get; }
        IUser User { get; }
    }
}