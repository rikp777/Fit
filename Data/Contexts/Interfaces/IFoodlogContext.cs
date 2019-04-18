using System.Collections.Generic;
using Models;

namespace Data.Contexts.Interfaces
{
    public interface IFoodlogContext
    {
        bool Create(IFoodlog foodlog);
        
        
        
        IFoodlog Read(int id);
        IFoodlog Read(IFoodlog foodlog);
        IFoodlog ReadLast(IUser user);
        
        
        
        bool Update(IFoodlog foodlog);
        
        
        
        bool Delete(int id);
        
        
        
        IEnumerable<IFoodlog> List();
        IEnumerable<IFoodlog> List(IUser user);      
    }
}