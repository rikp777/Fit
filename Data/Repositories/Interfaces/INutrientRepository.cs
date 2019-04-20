using System.Collections.Generic;
using Models;

namespace Data.Repositories.Interfaces
{
    public interface INutrientRepository
    {
        INutrient GetBy(int id);
        INutrient GetBy(string name);
        INutrient GetBy(INutrient nutrient);        
        
        
        
        IEnumerable<INutrient> GetAll();
        
        
        
        bool Add(INutrient nutrient);
        bool Edit(INutrient nutrient);
        bool Delete(int id);
    }
}