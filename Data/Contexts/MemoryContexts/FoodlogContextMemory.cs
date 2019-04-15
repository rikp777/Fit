using System;
using System.Collections.Generic;
using System.Linq;
using Data.Contexts.Interfaces;
using Data.dto;
using Enum;
using Interfaces;

namespace Data.Contexts.MemoryContexts
{
    public class FoodlogContextMemory : IFoodlogContext
    {
        private static List<IFoodlog> Foodlogs;
        private static bool Added;

        public FoodlogContextMemory()
        {
            if (!Added)
            {
                Foodlogs = new List<IFoodlog>();
                Foodlogs.Add(new FoodlogDto()
                {
                    Id = 1,
                    Amount = 2,
                    Unit = Unit.Stuks,                   
                    DateTime = DateTime.Now,
                    Article = new ArticleContextMemory().Read(1),
                    User = new UserContextMemory().Read(1)
                });
                Foodlogs.Add(new FoodlogDto()
                {
                    Id = 2,
                    Amount = 5,
                    Unit = Unit.Stuks,
                    DateTime = DateTime.Now,
                    Article = new ArticleContextMemory().Read(2),
                    User = new UserContextMemory().Read(1)
                });
                Foodlogs.Add(new FoodlogDto()
                {
                    Id = 2,
                    Amount = 10,
                    Unit = Unit.Gram,
                    DateTime = DateTime.Now,
                    Article = new ArticleContextMemory().Read(2),
                    User = new UserContextMemory().Read(2)
                });

                Added = true;      
            }
        }

        public IFoodlog Read(int id)
        {
            return Foodlogs.SingleOrDefault(u => u.Id == id);
        }

        public IEnumerable<IFoodlog> List()
        {
            return new List<IFoodlog>(Foodlogs);
        }
        public IEnumerable<IFoodlog> ListFromUser(IUser user)
        {
            return new List<IFoodlog>(Foodlogs).Where(f => f.User.Id == user.Id);
        }

        public bool Create(IFoodlog foodlog)
        {
            FoodlogDto foodlogDto = new FoodlogDto
            {
                Amount = foodlog.Amount,
                DateTime = foodlog.DateTime,
                User = foodlog.User,
                Unit = foodlog.Unit,
                Article = foodlog.Article
            };
            if (foodlogDto.Id == 0)
            {
                foodlogDto.Id = Foodlogs.Max(u => u.Id) + 1;
            }
            if (Foodlogs.SingleOrDefault(f => f.Id == foodlog.Id) == null)
            {              
                Foodlogs.Add(foodlogDto);
                return true;
            }
            return false;
        }

        public bool Update(IFoodlog foodlog)
        {
            try
            {
                Foodlogs[(int) (foodlog.Id) - 1] = (FoodlogDto) foodlog;
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
                Foodlogs.Remove(Foodlogs.SingleOrDefault(f => f.Id == id));
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return false;
        }
    }
}