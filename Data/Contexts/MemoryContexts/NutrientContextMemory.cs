using System.Collections.Generic;
using Data.dto;
using Interfaces;

namespace Data.Contexts.MemoryContexts
{
    public class NutrientContextMemory
    {
        private static List<INutrient> Nutrients;
        private static bool Added;

        public NutrientContextMemory()
        {
            if (!Added)
            {
                Nutrients = new List<INutrient>();
                Nutrients.Add(new NutrientDto()
                {                 
                    Id = 1,
                    Name = "Vet",
                    MaxIntake = 44 
                });
                Nutrients.Add(new NutrientDto()
                {                   
                    Id = 2,
                    Name = "Natrium",
                    MaxIntake = 1.5
                });
                Nutrients.Add(new NutrientDto()
                {                   
                    Id = 3,
                    Name = "Kalium ",
                    MaxIntake = 4.7
                });
                Nutrients.Add(new NutrientDto()
                {                   
                    Id = 4,
                    Name = "Eiwit",
                    MaxIntake = 46 
                });
                Nutrients.Add(new NutrientDto()
                {                   
                    Id = 5,
                    Name = "Koolhydraten ",
                    MaxIntake = 150
                });                
            }           
            Added = true; 
        }
        public IEnumerable<INutrient> List()
        {
            IEnumerable<INutrient> nutrients = Nutrients;
            return nutrients;
        }
    }
}