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
    public class NutrientRepository : INutrientRepository
    {
        private readonly INutrientContext _context;

        public NutrientRepository(StorageTypeSetting.StorageTypes storageType)
        {
            switch (storageType)
            {
                case StorageTypeSetting.StorageTypes.SQL :
                    _context = new NutrientContextSQL();   
                    break;
                case StorageTypeSetting.StorageTypes.Memory:
                    _context = new NutrientContextMemory();  
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(storageType), storageType, "Set Storage Type");
            }
        }





        public INutrient GetBy(int id) => _context.Read(id);
        public INutrient GetBy(string name) => _context.Read(name);
        public INutrient GetBy(INutrient nutrient) => _context.Read(nutrient);





        public IEnumerable<INutrient> GetAll() => _context.List();





        public bool Add(INutrient nutrient) => _context.Create(nutrient);
        public bool Edit(INutrient nutrient) => _context.Update(nutrient);
        public bool Delete(int id) => _context.Delete(id);
    }
}