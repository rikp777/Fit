using System;
using System.Collections.Generic;
using System.Linq;
using Data.Contexts.Interfaces;
using Data.Dto;
using Models;

namespace Data.Contexts.MemoryContexts
{
    public class WeightlogContextMemory : IWeightlogContext
    {
        private static List<IWeightlog> _weightlogs;
        private static bool _added;
        
        public WeightlogContextMemory()
        {
            if (_added) return;
            _weightlogs = new List<IWeightlog>
            {
                new WeightlogDto
                {
                    Id = 1,
                    DateTime = DateTime.Now,
                    Weight = 73,
                    User = new UserContextMemory().Read(1)
                }
            };
            _added = true;
        }
        private static WeightlogDto Map(IWeightlog weightlog)
        {
            var weightlogDto = new WeightlogDto
            {
                Id = _weightlogs.Max(u => u.Id) + 1,
                DateTime = weightlog.DateTime,
                Weight = weightlog.Weight,
                User = weightlog.User
            };
            return weightlogDto;
        }
        
        
        
        
        
        public bool Create(IWeightlog weightlog)
        {                      
            _weightlogs.Add(Map(weightlog));
            return true;
        }

        
        
        
        
        public IWeightlog Read(int id)
        {
            return _weightlogs.FirstOrDefault(w => w.Id == id);
        }
        public IWeightlog Read(IWeightlog weightlog)
        {
            return _weightlogs.FirstOrDefault(w => w.Id == weightlog.Id);
        }

        
        
        
        
        public bool Update(IWeightlog weightlog)
        {
            try
            {
                _weightlogs[weightlog.Id - 1] = Map(weightlog);
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
                _weightlogs.Remove(_weightlogs.SingleOrDefault(w => w.Id == id));
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return false;
        }

        
        
        
        
        public IEnumerable<IWeightlog> List()
        {
            return _weightlogs;
        }
    }
}