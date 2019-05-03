using System.Collections.Generic;
using Data.Contexts;
using Data.Repositories;
using Models;

namespace Logic
{
    public class GoalLogLogic
    {
        private readonly GoalLogRepository _goalLogRepository;

        public GoalLogLogic()
        {
            _goalLogRepository = new GoalLogRepository(StorageTypeSetting.Setting);
        }        
        
        
        
        
        
        public IGoalLog GetBy(int id) => _goalLogRepository.GetBy(id);
        public IGoalLog GetLastBy(IUser user) => _goalLogRepository.GetLastBy(user);
        
        
        
        
        public IEnumerable<IGoalLog> GetAll() => _goalLogRepository.GetAll();
        public IEnumerable<IGoalLog> GetAllBy(IUser user) => _goalLogRepository.GetAllBy(user);
        
        
        
        
        public bool Add(int userId, IGoalLog goalLog)
        {
            return _goalLogRepository.Add(goalLog);
        }
    }
}