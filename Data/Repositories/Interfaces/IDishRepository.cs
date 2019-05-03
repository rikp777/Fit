using System.Collections.Generic;
using Models;

namespace Data.Repositories.Interfaces
{
    public interface IDishRepository
    {
        IDish GetBy(int id);
        IDish GetBy(string name);
        IDish GetBy(IDish dish);        
        
        
        
        IEnumerable<IDish> GetAll();
        
        
        
        bool Add(IDish dish);
        bool Edit(IDish dish);
        bool Delete(int id);
    }
}