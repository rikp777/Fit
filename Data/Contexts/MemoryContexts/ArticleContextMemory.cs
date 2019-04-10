using System;
using System.Collections.Generic;
using System.Linq;
using Data.Contexts.Interfaces;
using Data.dto;
using Interfaces;

namespace Data.Contexts.MemoryContexts
{
    public class ArticleContextMemory : IArticleContext
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

        public IArticle Read(int id)
        {
            return Articles.SingleOrDefault(u => u.Id == id);
        }

        public IArticle Read(string name)
        {
            return Articles.SingleOrDefault(u => u.Name == name);
        }

        public IEnumerable<IArticle> List()
        {
            IEnumerable<IArticle> IArticles = new List<IArticle>(Articles);
            return IArticles;
        }

        public bool Create(IArticle article)
        {
            if (Articles.SingleOrDefault(u => u.Name == article.Name) == null && Articles.SingleOrDefault(u => u.Id == article.Id) == null)
            {
                Articles.Add((ArticleDto) article);
                return true;
            }
            return false;
        }

        public bool Update(IArticle article)
        {
            try
            {
                Articles[(int) (article.Id) - 1] = (ArticleDto) article;
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
                Articles.Remove(Articles.SingleOrDefault(u => u.Id == id));
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