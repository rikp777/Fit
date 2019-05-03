using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Data.Contexts.Interfaces;
using Data.Dto;
using Models;

namespace Data.Contexts.MemoryContexts
{
    public class GoalLogContextMemory : IGoalLogContext
    {
        private static List<IGoalLog> _goalLogs;
        private static bool _added;

        public GoalLogContextMemory()
        {
            if (_added) return;
            
            _goalLogs = new List<IGoalLog>
            {
                new GoalLogDto
                {
                    Id = 1, Calories = 2000, 
                    DateTime = DateTime.Now, 
                    User = new UserContextMemory().Read(1)
                },
                new GoalLogDto
                {
                    Id = 1, Calories = 2000, 
                    DateTime =  new DateTime(2019 , 2, 14), 
                    User = new UserContextMemory().Read(1)
                }
            };
            
            _added = true;
        }

        private static GoalLogDto Map(IGoalLog goalLog)
        {
            var goalLogDto = new GoalLogDto
            {
                Id = _goalLogs.Max(u => u.Id) + 1,
                DateTime = goalLog.DateTime,
                User = goalLog.User,
                Calories = goalLog.Calories
            };
            return goalLogDto;
        }
        
        
        
        
        
        public bool Create(IGoalLog goalLog)
        {
            var goalLogDto = Map(goalLog);
            goalLogDto.Id = _goalLogs.Count;
            
            _goalLogs.Add(goalLogDto);
            
            
            return true;
        }

        
        
        
        
        public IGoalLog Read(int id)
        {
            return _goalLogs.FirstOrDefault(g => g.Id == id);
        }
        public IGoalLog Read(IGoalLog goalLog)
        {
            return _goalLogs.FirstOrDefault(g => g.Id == goalLog.Id);
        }
        public IGoalLog ReadLast(IUser user)
        {
            return _goalLogs.FirstOrDefault(g => g.User.Id == user.Id);
        }

        
        

        
        public bool Update(IGoalLog goalLog)
        {
            if (_goalLogs.SingleOrDefault(f => f.DateTime == goalLog.DateTime) != null) return false;
            try
            {             
                _goalLogs[goalLog.Id - 1] = Map(goalLog);
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
                _goalLogs.Remove(_goalLogs.SingleOrDefault(g => g.Id == id));
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return false;
        }

        
               
        
        
        public IEnumerable<IGoalLog> List()
        {
            return _goalLogs;
        }
        public IEnumerable<IGoalLog> List(IUser user)
        {
            return _goalLogs.Where(g => g.User.Id == user.Id);
        }
    }
}