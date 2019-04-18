using System.Collections.Generic;
using Models;

namespace Data.Contexts.Interfaces
{
    public interface IWeightlogContext
    {
        bool Create(IWeightlog weightlog);
        
        
        
        IWeightlog Read(int id);
        IWeightlog Read(IWeightlog weightlog);
              
        
        
        bool Update(IWeightlog weightlog);
        
        
        
        bool Delete(int id);
        
        
        
        IEnumerable<IWeightlog> List();
    }
}