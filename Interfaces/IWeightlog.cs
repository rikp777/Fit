using System;

namespace Models
{
    public interface IWeightlog
    {
        int Id { get; }
        DateTime DateTime { get; }
        decimal Weight { get; }
        IUser User { get; }
    }
}