using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Data.Contexts.Interfaces;
using Data.Dto;
using Helpers;
using Models;

namespace Data.Contexts.SQLContexts
{
    public class ArticleContextSQL : IArticleContext
    {
        private static List<ArticleDto> _articles;

        public ArticleContextSQL()
        {
            InstantiateArticleContextSQL();
        }

        private static void InstantiateArticleContextSQL()
        {
            _articles = HelpFunctions.Query("Article_GetAll").DataTableToList<ArticleDto>();
            foreach (var article in _articles)
            {
                article.NutrientIntakes = List(article.Id);
            }
        }
        
        
        
        
        
        public bool Create(IArticle article)
        {
            
            var parameters = new Dictionary<string, object>
            {
                {"Name", article.Name}, 
                {"Calories", article.Calories}
            };


            var success = HelpFunctions.nonQuery("Article_Insert", parameters);
            
            InstantiateArticleContextSQL();
            
            return success;
        }  
        public bool CreateNutrientIntake(int articleId, INutrientIntake nutrientIntake)
        {
            
            var parameters = new Dictionary<string, object>
            {
                {"Article_Id", articleId},
                {"Amount", nutrientIntake.Amount},
                {"Nutrient_ID", nutrientIntake.Nutrient.Id}
            };


            var success = HelpFunctions.nonQuery("ArticleNutrient_Insert", parameters);
            
            InstantiateArticleContextSQL();
            
            return success;
        }
        
        
        
        

        public IArticle Read(int id)
        {
            var articleDto = _articles.FirstOrDefault(a => a.Id == id);
            
            return articleDto;
        }
        public IArticle Read(string name)
        {
            var articleDto = _articles.FirstOrDefault(a => a.Name == name);

            return articleDto;
        }
        public IArticle Read(IArticle article)
        {
            var articleDto = Read(article.Id);
            
            return articleDto;
        }

        
        
        
        
        public bool Update(IArticle article)
        {
            var parameters = new Dictionary<string, object>
            {
                {"Id", article.Id},
                {"Name", article.Name},
                {"Calories", article.Calories}
            };


            var success = HelpFunctions.nonQuery("Article_Update", parameters);

            InstantiateArticleContextSQL();
            
            return success;
        }
        public bool UpdateNutrientIntake(int articleId, INutrientIntake nutrientIntake)
        {
            var parameters = new Dictionary<string, object>
            {
                {"Article_Id", articleId},
                {"Nutrient_Id", nutrientIntake.Nutrient.Id},
                {"Amount", nutrientIntake.Amount}
            };


            var success = HelpFunctions.nonQuery("ArticleNutrient_Update", parameters);

            InstantiateArticleContextSQL();
            
            return success;
        }
        
        
        
        
        
        public bool Delete(int id)
        {
            var parameters = new Dictionary<string, object>
            {
                {"Id", id}
            };


            var success = HelpFunctions.nonQuery("Article_Delete", parameters);

            InstantiateArticleContextSQL();
            
            return success;
        }
        public bool DeleteNutrientIntake(int articleId, INutrientIntake nutrientIntake)
        {
            var parameters = new Dictionary<string, object>
            {
                {"Article_Id", articleId},
                {"Nutrient_Id", nutrientIntake.Nutrient.Id}
            };


            var success = HelpFunctions.nonQuery("ArticleNutrient_Delete", parameters);

            InstantiateArticleContextSQL();
            
            return success;
        }
        
        
        
        
        
        public IEnumerable<IArticle> List()
        {
            var articlesDto = _articles;
            return articlesDto;
        }


        
        
        
        
        
        
        
        
        
        private static IEnumerable<INutrientIntake> List(int articleId)
        {
            var parameters = new Dictionary<string, object>
            {
                {"Article_Id", articleId}
            };
            
            var dataTable = HelpFunctions.Query("ArticleNutrient_GetAllByArticleId", parameters);
            var nutrientIntakesDto = dataTable.DataTableToList<NutrientIntakeDto>();
            var i = 0;
            foreach (var nutrientIntake in nutrientIntakesDto)
            {
                nutrientIntake.Nutrient = new NutrientContextSQL().Read((int) dataTable.Rows[i]["Nutrient_Id"]);
                i++;
            }
            return nutrientIntakesDto;
        }

//        private static ArticleDto BuildArticleDto(DataTable dataTable)
//        {
//            var nutrientIntakesDto = new List<INutrientIntake>();
//
//            foreach (DataRow row in dataTable.Rows)
//            {
//                var nutrientIntakeDto = new NutrientIntakeDto
//                {
//                    Amount = (decimal) row["Amount"],
//                    Nutrient = new NutrientDto
//                    {
//                        Id = (int) row["Id"],
//                        MaxIntake = (decimal) row["Max_Intake"],
//                        Name = (string) row["Name"]
//                    }
//                };
//                nutrientIntakesDto.Add(nutrientIntakeDto);
//            }
//            var articleDto = new ArticleDto
//            {
//                Id = (int) dataTable.Rows[0]["Id"],
//                Name = (string) dataTable.Rows[0]["Name"],
//                Calories = (int) dataTable.Rows[0]["Calories"],
//                NutrientIntakes = nutrientIntakesDto
//            };
//            
//            
//            return articleDto;
//        }
    }
}