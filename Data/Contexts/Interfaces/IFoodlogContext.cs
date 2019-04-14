using System.Collections.Generic;
using Interfaces;

namespace Data.Contexts.Interfaces
{
    public interface IFoodlogContext
    {
        IFoodlog Read(int id);
        IEnumerable<IFoodlog> List();
        IEnumerable<IFoodlog> ListFromUser(IUser user);
        bool Create(IFoodlog foodlog);
        bool Update(IFoodlog foodlog);
        bool Delete(int id);
    }
}