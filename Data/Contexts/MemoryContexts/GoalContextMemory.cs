using System;
using System.Collections.Generic;
using System.Linq;
using Data.Contexts.Interfaces;
using Data.Dto;
using Models;

namespace Data.Contexts.MemoryContexts
{
    public class GoalContextMemory : IGoalContext
    {
        private static List<IGoal> _goals;
        private static bool _added;

        public GoalContextMemory()
        {
            if (_added) return;
            
            _goals = new List<IGoal>
            {
                new GoalDto
                {
                    Id = 1, Calories = 2000, 
                    DateTime = DateTime.Now, 
                    User = new UserContextMemory().Read(1)
                },
                new GoalDto
                {
                    Id = 1, Calories = 2000, 
                    DateTime =  new DateTime(2019 , 2, 14), 
                    User = new UserContextMemory().Read(1)
                }
            };
            
            _added = true;
        }

        private static GoalDto Map(IGoal goal)
        {
            var GoalDto = new GoalDto
            {
                Id = _goals.Max(u => u.Id) + 1,
                DateTime = goal.DateTime,
                User = goal.User,
                Calories = goal.Calories
            };
            return GoalDto;
        }
        
        
        
        
        
        public bool Create(IGoal goal)
        {         
            _goals.Add(Map(goal));
            return true;
        }

        
        
        
        
        public IGoal Read(int id)
        {
            return _goals.FirstOrDefault(g => g.Id == id);
        }
        public IGoal Read(IGoal goal)
        {
            return _goals.FirstOrDefault(g => g.Id == goal.Id);
        }

        
        
        
        
        public bool Update(IGoal goal)
        {
            if (_goals.SingleOrDefault(f => f.DateTime == goal.DateTime) != null) return false;
            try
            {             
                _goals[goal.Id - 1] = Map(goal);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return false;
        }

        
        
        
        
        public bool Delete(int id)
        {
            try
            {
                _goals.Remove(_goals.SingleOrDefault(g => g.Id == id));
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return false;
        }

        
               
        
        
        public IEnumerable<IGoal> List()
        {
            return _goals;
        }
    }
}