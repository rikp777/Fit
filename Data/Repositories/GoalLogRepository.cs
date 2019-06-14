using System;
using System.Collections.Generic;
using Data.Contexts;
using Data.Contexts.Interfaces;
using Data.Contexts.MemoryContexts;
using Data.Contexts.SQLContexts;
using Data.Repositories.Interfaces;
using Models;

namespace Data.Repositories
{
    public class GoalLogRepository : IGoalLogRepository
    {
        private readonly IGoalLogContext _context;

        public GoalLogRepository(StorageTypeSetting.StorageTypes storageType)
        {
            switch (storageType)
            {
                case StorageTypeSetting.StorageTypes.SQL :
                    _context = new GoalLogsContextSql();
                    break;
                case StorageTypeSetting.StorageTypes.Memory:
                    _context = new GoalLogContextMemory();  
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(storageType), storageType, "Set Storage Type");
            }
        }




        public IGoalLog GetBy(int id) => _context.Read(id);
        public IGoalLog GetBy(IGoalLog goalLog) => _context.Read(goalLog);
        public IGoalLog GetLastBy(IUser user) => _context.ReadLast(user);



        public IEnumerable<IGoalLog> GetAll() => _context.List();
        public IEnumerable<IGoalLog> GetAllBy(IUser user) => _context.List(user);



        public bool Add(IGoalLog goalLog) => _context.Create(goalLog);
        public bool Edit(IGoalLog goalLog) => _context.Update(goalLog);
        public bool Delete(int id) => _context.Delete(id);
    }
}