using System;
using System.Collections.Generic;
using System.Linq;
using Data.Contexts.Interfaces;
using Data.Dto;
using Enum;
using Models;

namespace Data.Contexts.MemoryContexts
{
    public class FoodlogContextMemory : IFoodlogContext
    {
        private static List<IFoodlog> _foodlogs;
        private static bool _added;

        public FoodlogContextMemory()
        {
            if (_added) return;
            _foodlogs = new List<IFoodlog>
            {
                new FoodlogDto
                {
                    Id = 1,
                    Amount = 2,
                    Unit = Unit.Stuks,
                    DateTime = DateTime.Now,
                    Article = new ArticleContextMemory().Read(1),
                    User = new UserContextMemory().Read(1)
                },
                new FoodlogDto
                {
                    Id = 2,
                    Amount = 5,
                    Unit = Unit.Stuks,
                    DateTime = DateTime.Now,
                    Article = new ArticleContextMemory().Read(2),
                    User = new UserContextMemory().Read(1)
                },
                new FoodlogDto
                {
                    Id = 3,
                    Amount = 10,
                    Unit = Unit.Gram,
                    DateTime = DateTime.Now,
                    Article = new ArticleContextMemory().Read(2),
                    User = new UserContextMemory().Read(2)
                }
            };
            _added = true;
        }
        private static FoodlogDto Map(IFoodlog foodlog)
        {         
            var foodlogDto = new FoodlogDto
            {
                Id = _foodlogs.Max(u => u.Id) + 1,
                Amount = foodlog.Amount,
                Article = foodlog.Article,
                DateTime = foodlog.DateTime,
                Unit = foodlog.Unit,
                User = foodlog.User
            };
            return foodlogDto;
        }
        
        
        
        
        
        public bool Create(IFoodlog foodlog)
        {      
            _foodlogs.Add(Map(foodlog));
            return true;
        }
        
        
        
        

        public IFoodlog Read(int id)
        {
            return _foodlogs.SingleOrDefault(u => u.Id == id);
        }
        public IFoodlog ReadLast(IUser user)
        {
            return _foodlogs.FindLast(u => u.User.Id == user.Id);
        }
        public IFoodlog Read(IFoodlog foodlog)
        {
            return _foodlogs.SingleOrDefault(f => f.Id == foodlog.Id);
        }


        
        
        
        public bool Update(IFoodlog foodlog)
        {
            try
            {
                _foodlogs[foodlog.Id - 1] = Map(foodlog);
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
                _foodlogs.Remove(_foodlogs.SingleOrDefault(f => f.Id == id));
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return false;
        }
        
        
        
              
        public IEnumerable<IFoodlog> List()
        {
            return _foodlogs;
        }
        public IEnumerable<IFoodlog> List(IUser user)
        {
            return _foodlogs.Where(f => f.User.Id == user.Id);
        }
    }
}