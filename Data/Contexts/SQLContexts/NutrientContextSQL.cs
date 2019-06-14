using System.Collections.Generic;
using System.Linq;
using Data.Contexts.Interfaces;
using Data.Dto;
using Helpers;
using Models;

namespace Data.Contexts.SQLContexts
{
    public class NutrientContextSQL : INutrientContext
    {
        private static List<NutrientDto> _nutrients;

        public NutrientContextSQL()
        {
            InstantiateContextSQL();
        }

        private static void InstantiateContextSQL()
        {
            _nutrients = HelpFunctions.Query("Nutrient_GetAll").DataTableToList<NutrientDto>();
        }
        
        
        
        
        
        public bool Create(INutrient nutrient)
        {
            var parameters = new Dictionary<string, object>
            {
                {"Name", nutrient.Name}, 
                {"MaxIntake", nutrient.MaxIntake}
            };

            var success = HelpFunctions.nonQuery("Nutrient_Insert", parameters);

            InstantiateContextSQL();
            
            return success;
        }

        
        
        
        
        public INutrient Read(int id)
        {
            var nutrientDto = _nutrients.FirstOrDefault(n => n.Id == id);

            return nutrientDto;
        }
        public INutrient Read(string name)
        {
            var nutrientDto = _nutrients.FirstOrDefault(n => n.Name == name);

            return nutrientDto;
        }
        public INutrient Read(INutrient nutrient)
        {
            var nutrientDto = Read(nutrient.Id);
            
            return nutrientDto;
        }

        
        
        
        
        public bool Update(INutrient nutrient)
        {
            var parameters = new Dictionary<string, object>
            {
                {"Id", nutrient.Id},
                {"Name", nutrient.Name}, 
                {"MaxIntake", nutrient.MaxIntake}
            };

            var success = HelpFunctions.nonQuery("Nutrient_Update", parameters);

            InstantiateContextSQL();
            
            return success;
        }

        
        
        
        
        public bool Delete(int id)
        {
            var parameters = new Dictionary<string, object>
            {
                {"Id", id} 
            };

            var success = HelpFunctions.nonQuery("Nutrient_Delete", parameters);

            InstantiateContextSQL();
            
            return success;
        }

        
        
        
        
        public IEnumerable<INutrient> List()
        {
            var nutrientsDto = _nutrients;

            return nutrientsDto;
        }
    }
}