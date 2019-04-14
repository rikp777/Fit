using System;

namespace Interfaces
{
    public interface IFoodlog
    {
        int Id { get; }
        int Amount { get; }
        DateTime DateTime { get; }
        IArticle Article { get; }
        IUser User { get; }
        Unit Unit { get; }
    }

    public enum Unit
    {
        Gram,
        Stuks,
    }
}