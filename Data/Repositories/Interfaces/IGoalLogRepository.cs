using System.Collections.Generic;
using Models;

namespace Data.Repositories.Interfaces
{
    public interface IGoalLogRepository
    {
        IGoalLog GetBy(int id);
        IGoalLog GetBy(IGoalLog goalLog);
        IGoalLog GetLastBy(IUser user);
        
        
        
        IEnumerable<IGoalLog> GetAll();
        IEnumerable<IGoalLog> GetAllBy(IUser user);   
        
        

        bool Add(IGoalLog goalLog);
        bool Edit(IGoalLog goalLog);
        bool Delete(int id);
    }
}