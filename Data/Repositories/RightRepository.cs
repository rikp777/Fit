using System;
using System.Collections.Generic;
using Data.Contexts;
using Data.Contexts.Interfaces;
using Data.Contexts.MemoryContexts;
using Data.Contexts.SQLContexts;
using Models;

namespace Data.Repositories
{
    public class RightRepository
    {
        private readonly IRightContext _context;

        public RightRepository(StorageTypeSetting.StorageTypes storageType)
        {
            switch (storageType)
            {
                case StorageTypeSetting.StorageTypes.SQL :
                    _context = new RightContextSQL();   
                    break;
                case StorageTypeSetting.StorageTypes.Memory:
                    _context = new RightContextMemory();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(storageType), storageType, "Set Storage Type");
            }
        }

        
        
        
        
        public IRight GetBy(int id) => _context.Read(id);
        public IRight GetBy(string name) => _context.Read(name);
        public IRight GetBy(IUser user) => _context.Read(user);

        
        
        
        
        public IEnumerable<IRight> GetAll() => _context.List();
    }
}