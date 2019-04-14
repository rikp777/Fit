using System.Collections.Generic;
using Data.Contexts;
using Data.Contexts.Interfaces;
using Data.Contexts.MemoryContexts;
using Data.Contexts.SQLContexts;
using Interfaces;

namespace Data.Repositories
{
    public class FoodlogRepository
    {
        private readonly IFoodlogContext _context;

        public FoodlogRepository(StorageTypeSetting.StorageTypes storageType)
        {
            switch (storageType)
            {
                case StorageTypeSetting.StorageTypes.SQL :
                    _context = new FoodlogContextSQL();   
                    break;
                default: 
                    _context = new FoodlogContextMemory();    
                    break; 
            }
        }

        public IFoodlog GetBy(int id)
        {
            IFoodlog foodlog = _context.Read(id);

            return foodlog;
        }
        
        public IEnumerable<IFoodlog> GetAll()
        {
            return _context.List();
        }
        public IEnumerable<IFoodlog> GetAllBy(IUser user)
        {
            return _context.ListFromUser(user);
        }
        
        public bool Add(IFoodlog foodlog)
        {
            return _context.Create(foodlog);
        }

        public bool Edit(IFoodlog foodlog)
        {
            return _context.Update(foodlog);
        }

        public bool Delete(int id)
        {
            return _context.Delete(id);
        }
    }
}