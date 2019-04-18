using System.Collections.Generic;
using Models;

namespace Data.Repositories.Interfaces
{
    public interface IFoodlogRepository
    {
        IFoodlog GetBy(int id);
        IFoodlog GetBy(IFoodlog foodlog);
        IFoodlog GetLastBy(IUser user);
        
        
        
        IEnumerable<IFoodlog> GetAll();
        IEnumerable<IFoodlog> GetAllBy(IUser user);   
        
        

        bool Add(IFoodlog foodlog);
        bool Edit(IFoodlog foodlog);
        bool Delete(int id);
        
    }
}