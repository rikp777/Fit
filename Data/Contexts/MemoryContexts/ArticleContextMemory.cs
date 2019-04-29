using System;
using System.Collections;
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
                Calories = article.Calories,
                Name = article.Name,       
                NutrientIntakes = article.NutrientIntakes
            };
            if (article.Id == null || article.Id == 0)
            {
                articleDto.Id = _articles.Max(u => u.Id) + 1;
            }
            else
            {
                articleDto.Id = article.Id;
            }
            if (article.Name != null)
            {
                articleDto.Name = article.Name;
            }
            return articleDto;
        }

        
        
        
        
        public bool Create(IArticle article)
        {
            if (_articles.SingleOrDefault(u => u.Name == article.Name) != null) return false;

            var OldArticle = Read(article);
            var newArticle = Map(article);
            if (OldArticle != null)
            {
                newArticle.NutrientIntakes = OldArticle.NutrientIntakes;  
            }
          
            _articles.Add(newArticle);
            
            return true;
        }
        public bool CreateNutrientIntake(int articleId, INutrientIntake newNutrientIntake)
        {
            var article = Map(Read(articleId));
            var nutrientIntakes = new List<NutrientIntakeDto>();
            if (article.NutrientIntakes != null)
            {
                nutrientIntakes = article.NutrientIntakes.Cast<NutrientIntakeDto>().ToList();
            }
            
            var newNutrientIntakeDto = new NutrientIntakeDto
            {
                Amount = newNutrientIntake.Amount,
                Nutrient = newNutrientIntake.Nutrient
            };
            
            
            nutrientIntakes.Add(newNutrientIntakeDto);
            article.NutrientIntakes = nutrientIntakes;
            
            _articles[article.Id - 1] = article;
            
            return true;
        }
        
        
        
        

        public IArticle Read(int id)
        {
            ArticleDto articles = _articles.SingleOrDefault(u => u.Id == id) as ArticleDto;
            return articles;
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
                var articleDto = Map(article);
                articleDto.NutrientIntakes = Read(article).NutrientIntakes;
//                //validation 
//                if (article.Name != null)
//                {
//                    if (_articles.SingleOrDefault(u => u.Name == article.Name) != null) return false;
//                }

                _articles[article.Id - 1] = articleDto;
                
                
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return false;
        }

        public bool UpdateNutrientIntake(int articleId, INutrientIntake newNutrientIntake)
        {
            var article = Map(Read(articleId));
            var nutrientIntakes = article.NutrientIntakes.Cast<NutrientIntakeDto>().ToList();

            foreach (var nutrientIntake in nutrientIntakes)
            {
                if (nutrientIntake.Nutrient.Name == newNutrientIntake.Nutrient.Name)
                {
                    nutrientIntake.Amount = newNutrientIntake.Amount;
                }
            }
                
            article.NutrientIntakes = nutrientIntakes;
            _articles[article.Id - 1] = article;
            return true;
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
        public bool DeleteNutrientIntake(int articleId, INutrientIntake delNutrientIntake)
        {
            try
            {
                var article = Map(Read(articleId));       
                var nutrientIntakes = article.NutrientIntakes.Cast<NutrientIntakeDto>().ToList();

                var delNutrientIntakes = nutrientIntakes.FirstOrDefault(n => n.Nutrient.Name == delNutrientIntake.Nutrient.Name);
                nutrientIntakes.Remove(delNutrientIntakes);
                article.NutrientIntakes = nutrientIntakes;
            
                _articles[article.Id - 1] = article;
            
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