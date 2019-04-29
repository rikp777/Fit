using System.Collections.Generic;
using Data.Dto;
using Models;

namespace Data.Contexts.Interfaces
{
    public interface INutrientContext
    {
        bool Create(INutrient nutrient);
        
        
        
        INutrient Read(int id);
        INutrient Read(string name);
        INutrient Read(INutrient nutrient);

        
        
        bool Update(INutrient nutrient);

        
            
        bool Delete(int id);
        
        
        
        IEnumerable<INutrient> List();
    }
}