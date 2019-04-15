using System;
using Enum;

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
}