using System.Collections.Generic;
using Models;

namespace Data.Repositories.Interfaces
{
    public interface IWeightLogRepository
    {
        IWeightlog GetBy(int id);
        IWeightlog GetBy(IWeightlog weightlog);
        IWeightlog GetLastBy(IUser user);
        
        
        
        IEnumerable<IWeightlog> GetAll();
        IEnumerable<IWeightlog> GetAllBy(IUser user);   
        
        

        bool Add(IWeightlog weightlog);
        bool Edit(IWeightlog weightlog);
        bool Delete(int id);
    }
}