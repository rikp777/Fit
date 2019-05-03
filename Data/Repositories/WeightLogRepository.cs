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
    public class WeightLogRepository : IWeightLogRepository
    {
        private readonly IWeightlogContext _context;

        public WeightLogRepository(StorageTypeSetting.StorageTypes storageType)
        {
            switch (storageType)
            {
                case StorageTypeSetting.StorageTypes.SQL :
                    _context = null;   //TODO implement 
                    break;
                case StorageTypeSetting.StorageTypes.Memory:
                    _context = new WeightlogContextMemory();  
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(storageType), storageType, "Set Storage Type");
            }
        }

        
        
        
        
        public IWeightlog GetBy(int id) => _context.Read(id);
        public IWeightlog GetBy(IWeightlog weightlog) => _context.Read(weightlog);
        public IWeightlog GetLastBy(IUser user) => _context.ReadLast(user);

        
        
        
        
        public IEnumerable<IWeightlog> GetAll() => _context.List();
        public IEnumerable<IWeightlog> GetAllBy(IUser user) => _context.List(user);





        public bool Add(IWeightlog weightlog) => _context.Create(weightlog);
        public bool Edit(IWeightlog weightlog) => _context.Update(weightlog);
        public bool Delete(int id) => _context.Delete(id);
    }
}