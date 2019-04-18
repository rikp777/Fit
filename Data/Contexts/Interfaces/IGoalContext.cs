using System.Collections.Generic;
using Models;

namespace Data.Contexts.Interfaces
{
    public interface IGoalContext
    {
        bool Create(IGoal goal);
        
        
        
        IGoal Read(int id);
        IGoal Read(IGoal goal);
        
        
        
        bool Update(IGoal goal);   
        
        
        
        bool Delete(int id);
        
        
        
        IEnumerable<IGoal> List();
    }
}