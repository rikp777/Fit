using System.Collections;
using System.Collections.Generic;
using Models;

namespace Data.Contexts.Interfaces
{
    public interface IWeightlogContext
    {
        bool Create(IWeightlog weightlog);
        
        
        
        IWeightlog Read(int id);
        IWeightlog Read(IWeightlog weightlog);
        IWeightlog ReadLast(IUser user);
              
        
        
        bool Update(IWeightlog weightlog);
        
        
        
        bool Delete(int id);
        
        
        
        IEnumerable<IWeightlog> List();
        IEnumerable<IWeightlog> List(IUser user);
    }
}