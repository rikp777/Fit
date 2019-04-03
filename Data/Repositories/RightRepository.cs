using System.Collections.Generic;
using Data.Contexts;
using Data.Contexts.Interfaces;
using Data.Contexts.MemoryContexts;
using Data.Contexts.SQLContexts;
using Interfaces;

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
                default: 
                    _context = new RightContextMemory();    
                    break; 
            }
        }
        
        public IRight GetBy(int id)
        {
            return _context.Read(id);
        }
        public IRight GetBy(string name)
        {
            return _context.Read(name);
        }
        public IRight GetBy(IUser user)
        {
            return _context.Read(user);
        }

        public List<IRight> GetAll()
        {
            return _context.List();
        }
    }
}