using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using Data.Contexts.Interfaces;
using Data.Contexts.SQLContexts;
using Data.Dto;
using Data.Repositories.Interfaces;
using Models;

namespace Data.Contexts.MemoryContexts
{
    public class ArticleContextMemory : IArticleContext
    {
        private static List<IArticle> _articles;
        private static bool _added;

        public ArticleContextMemory()
        {
            if (_added) return;
            var nutrients = new NutrientContextMemory().List();
            _articles = new List<IArticle>
            {
                new ArticleDto
                {
                    Id = 1,
                    Name = "Banaan",
                    Calories = 86,
                    NutrientIntakes = new List<INutrientIntake>
                    {
                        new NutrientIntakeDto
                        {
                            Nutrient = nutrients.SingleOrDefault(n => n.Id == 1), Amount = 0.3
                        },
                        new NutrientIntakeDto
                        {
                            Nutrient = nutrients.SingleOrDefault(n => n.Id == 2), Amount = 0.001
                        },
                        new NutrientIntakeDto
                        {
                            Nutrient = nutrients.SingleOrDefault(n => n.Id == 3), Amount = 4.7
                        },
                        new NutrientIntakeDto
                        {
                            Nutrient = nutrients.SingleOrDefault(n => n.Id == 4), Amount = 23
                        },
                        new NutrientIntakeDto
                        {
                            Nutrient = nutrients.SingleOrDefault(n => n.Id == 5), Amount = 46
                        }
                    }
                },
                new ArticleDto
                {
                    Id = 2,
                    Name = "Appel",
                    Calories = 86,
                    NutrientIntakes = new List<INutrientIntake>
                    {
                        new NutrientIntakeDto
                        {
                            Nutrient = nutrients.SingleOrDefault(n => n.Id == 1), Amount = 44
                        },
                        new NutrientIntakeDto
                        {
                            Nutrient = nutrients.SingleOrDefault(n => n.Id == 4), Amount = 150
                        },
                        new NutrientIntakeDto
                        {
                            Nutrient = nutrients.SingleOrDefault(n => n.Id == 5), Amount = 46
                        }
                    }
                }
            };
            _added = true;
        }
        private static ArticleDto Map(IArticle article)
        {     
            var articleDto = new ArticleDto
            {
                Id =  _articles.Max(u => u.Id) + 1,
                Name = article.Name,
                Calories = article.Calories,
                NutrientIntakes = article.NutrientIntakes               
            };
            return articleDto;
        }

        
        
        
        
        public bool Create(IArticle article)
        {
            if (_articles.SingleOrDefault(u => u.Name == article.Name) != null) return false;
                       
            _articles.Add(Map(article));
            
            return true;
        }
        
        
        
        

        public IArticle Read(int id)
        {
            return _articles.SingleOrDefault(u => u.Id == id);
        }
        public IArticle Read(string name)
        {
            return _articles.SingleOrDefault(u => u.Name == name);
        }
        public IArticle Read(IArticle article)
        {
            return _articles.SingleOrDefault(u => u.Id == article.Id);
        }
        
        
        
        

        public bool Update(IArticle article)
        {
            try
            {
                if (_articles.SingleOrDefault(u => u.Name == article.Name) != null) return false;
                
                _articles[article.Id - 1] = Map(article);
                
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
                _articles.Remove(_articles.SingleOrDefault(u => u.Id == id));
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return false;
        }
        
        
        
        
        
        public IEnumerable<IArticle> List()
        {
            return _articles;
        }

        
        
        
        
        //TODO ListMostPopular 
        public IEnumerable<IArticle> ListMostPopular()
        {
            return null;
        }
    }
}