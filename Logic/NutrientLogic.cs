using System;
using System.Collections.Generic;
using Data.Contexts;
using Data.Repositories;
using Models;

namespace Logic
{
    public class NutrientLogic
    {
        private readonly NutrientRepository _nutrientRepository;

        public NutrientLogic()
        {
            _nutrientRepository = new NutrientRepository(StorageTypeSetting.Setting);
        }
        
        
        
        
        
        public INutrient GetBy(int id) => _nutrientRepository.GetBy(id);
        public INutrient GetBy(string name) => _nutrientRepository.GetBy(name);
        public INutrient GetBy(INutrient nutrient) => _nutrientRepository.GetBy(nutrient);
        
        
        
        
        public IEnumerable<INutrient> GetAll() => _nutrientRepository.GetAll();
    }
}