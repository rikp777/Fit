using System;
using System.Collections.Generic;
using System.Linq;
using Data.Contexts.Interfaces;
using Data.Dto;
using Models;

namespace Data.Contexts.MemoryContexts
{
    public class NutrientContextMemory : INutrientContext
    {
        private static List<INutrient> _nutrients;
        private static bool _added;

        public NutrientContextMemory()
        {
            if (_added) return;

            _nutrients = new List<INutrient>
            {
                new NutrientDto {Id = 1, Name = "Vet", MaxIntake = 44},
                new NutrientDto {Id = 2, Name = "Natrium", MaxIntake = 1.5m},
                new NutrientDto {Id = 3, Name = "Kalium ", MaxIntake = 4.7m},
                new NutrientDto {Id = 4, Name = "Eiwit", MaxIntake = 46},
                new NutrientDto {Id = 5, Name = "Koolhydraten ", MaxIntake = 150}
            };
        
            _added = true; 
        }
        private static NutrientDto Map(INutrient nutrient)
        {
            var nutrientDto = new NutrientDto
            {
                Id = _nutrients.Max(u => u.Id) + 1,
                Name = nutrient.Name,
                MaxIntake = nutrient.MaxIntake
            };
            return nutrientDto;
        }

        
        
        
        
        public bool Create(INutrient nutrient)
        {        
            if (_nutrients.SingleOrDefault(f => f.Name == nutrient.Name) != null) return false;      
            
            _nutrients.Add(Map(nutrient));
            
            return true;
        }

        
        
        
        
        public INutrient Read(int id)
        {
            return _nutrients.SingleOrDefault(n => n.Id == id);
        }
        public INutrient Read(string name)
        {
            return _nutrients.SingleOrDefault(n => n.Name == name);
        }
        public INutrient Read(INutrient nutrient)
        {
            return _nutrients.SingleOrDefault(n => n.Id == nutrient.Id);
        }

        
        
        
        
        public bool Update(INutrient nutrient)
        {
            if (_nutrients.SingleOrDefault(n => n.Name == nutrient.Name) != null) return false;
            try
            {             
                _nutrients[nutrient.Id - 1] = Map(nutrient);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return false;
        }

        
        
        
        
        public bool Delete(int id)
        {
            try
            {
                _nutrients.Remove(_nutrients.SingleOrDefault(n => n.Id == id));
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return false;
        }

        
        
        
        
        public IEnumerable<INutrient> List()
        {
            return _nutrients;
        }
    }
}