using System.Collections;
using System.Collections.Generic;
using Models;

namespace Data.Contexts.Interfaces
{
    public interface IGoalLogContext
    {
        bool Create(IGoalLog goalLog);
        
        
        
        IGoalLog Read(int id);
        IGoalLog Read(IGoalLog goalLog);
        IGoalLog ReadLast(IUser user);
        
        
        
        bool Update(IGoalLog goalLog);   
        
        
        
        bool Delete(int id);
        
        
        
        IEnumerable<IGoalLog> List();
        IEnumerable<IGoalLog> List(IUser user);
    }
}