using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Data.Contexts.Interfaces;
using Data.Dto;
using Helpers;
using Models;

namespace Data.Contexts.SQLContexts
{
    public class ArticleContextSQL : IArticleContext
    {
        public bool CreateNutrientIntake(int articleId, INutrientIntake newNutrientIntake)
        {
            throw new System.NotImplementedException();
        }

        public IArticle Read(int id)
        {
            throw new System.NotImplementedException();
        }

        public IArticle Read(string name)
        {
            throw new System.NotImplementedException();
        }

        public IArticle Read(IArticle article)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteNutrientIntake(int articleId, INutrientIntake newNutrientIntake)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<IArticle> List()
        {
            var data = HelpFunctions.Query("Article_GetAll");
            var articles = data.DataTableToList<ArticleDto>();
            return articles;
        }

        public bool Create(IArticle article)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(IArticle article)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateNutrientIntake(int articleId, INutrientIntake newNutrientIntake)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }
        
        
        
        
        
         
    }
}