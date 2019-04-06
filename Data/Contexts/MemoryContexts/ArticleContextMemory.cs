using System.Collections.Generic;
using System.Linq;
using Data.dto;
using Interfaces;

namespace Data.Contexts.MemoryContexts
{
    public class ArticleContextMemory
    {
        private static List<IArticle> Articles;
        private static bool Added;

        public ArticleContextMemory()
        {
            if (!Added)
            {
                IEnumerable<INutrient> nutrients = new NutrientContextMemory().List();
                Articles = new List<IArticle>();
                Articles.Add(new ArticleDto()
                {
                    Id = 1,
                    Name = "Banaan",
                    Calories = 86,
                    Nutrients = new List<INutrientIntake>
                    {
                        new NutrientIntakeDto()
                        {
                            Nutrient = nutrients.SingleOrDefault(n => n.Id == 1),
                            Amount = 0.3                             
                        },
                        new NutrientIntakeDto()
                        {
                            Nutrient = nutrients.SingleOrDefault(n => n.Id == 2),
                            Amount = 0.001                             
                        },
                        new NutrientIntakeDto()
                        {
                            Nutrient = nutrients.SingleOrDefault(n => n.Id == 3),
                            Amount = 4.7                             
                        },
                        new NutrientIntakeDto()
                        {
                            Nutrient = nutrients.SingleOrDefault(n => n.Id == 4),
                            Amount = 23                         
                        },
                        new NutrientIntakeDto()
                        {
                            Nutrient = nutrients.SingleOrDefault(n => n.Id == 5),
                            Amount = 46                            
                        }                      
                    }
                });
                Articles.Add(new ArticleDto()
                {
                    Id = 1,
                    Name = "Appel",
                    Calories = 86,
                    Nutrients = new List<INutrientIntake>
                    {
                        new NutrientIntakeDto()
                        {
                            Nutrient = nutrients.SingleOrDefault(n => n.Id == 1),
                            Amount = 44                            
                        },
                        new NutrientIntakeDto()
                        {
                            Nutrient = nutrients.SingleOrDefault(n => n.Id == 4),
                            Amount = 150                      
                        },
                        new NutrientIntakeDto()
                        {
                            Nutrient = nutrients.SingleOrDefault(n => n.Id == 5),
                            Amount = 46                            
                        }                      
                    }
                });
                Added = true;      
            }
        } 
    }
}