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
    public class FoodlogRepository : IFoodlogRepository
    {
        private readonly IFoodlogContext _context;

        public FoodlogRepository(StorageTypeSetting.StorageTypes storageType)
        {
            switch (storageType)
            {
                case StorageTypeSetting.StorageTypes.SQL :
                    _context = new FoodlogContextSQL();   
                    break;
                case StorageTypeSetting.StorageTypes.Memory:
                    _context = new FoodlogContextMemory();  
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(storageType), storageType, "Set Storage Type");
            }
        }

        
        
        
        
        public IFoodlog GetBy(int id) => _context.Read(id);
        public IFoodlog GetBy(IFoodlog foodlog) => _context.Read(foodlog);
        public IFoodlog GetLastBy(IUser user) => _context.ReadLast(user);

        
        
        
        
        public IEnumerable<IFoodlog> GetAll() => _context.List();
        public IEnumerable<IFoodlog> GetAllBy(IUser user) => _context.List(user);





        public bool Add(IFoodlog foodlog) => _context.Create(foodlog);
        public bool Edit(IFoodlog foodlog) => _context.Update(foodlog);
        public bool Delete(int id) => _context.Delete(id);
    }
}