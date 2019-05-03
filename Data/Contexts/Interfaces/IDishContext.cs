using System.Collections.Generic;
using Models;

namespace Data.Contexts.Interfaces
{
    public interface IDishContext
    {
        bool Create(IDish dish);
        
        
        
        IDish Read(int id);
        IDish Read(string name);
        IDish Read(IDish dish);

        
        
        bool Update(IDish dish);

        
            
        bool Delete(int id);
        
        
        
        IEnumerable<IDish> List();
    }
}