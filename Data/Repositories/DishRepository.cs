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
    public class DishRepository : IDishRepository
    {
        private readonly IDishContext _context;

        public DishRepository(StorageTypeSetting.StorageTypes storageType)
        {
            switch (storageType)
            {
                case StorageTypeSetting.StorageTypes.SQL :
                    _context = new DishContextSQL();   
                    break;
                case StorageTypeSetting.StorageTypes.Memory:
                    _context = new DishContectMemory();  
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(storageType), storageType, "Set Storage Type");
            }
        }



        

        public IDish GetBy(int id) => _context.Read(id);
        public IDish GetBy(string name) => _context.Read(name);
        public IDish GetBy(IDish dish) => _context.Read(dish);





        public IEnumerable<IDish> GetAll() => _context.List();






        public bool Add(IDish dish) => _context.Create(dish);
        public bool Edit(IDish dish) => _context.Update(dish);
        public bool Delete(int id) => _context.Delete(id);
    }
}