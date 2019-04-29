using System.Collections.Generic;
using Data.Contexts.Interfaces;
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
            throw new System.NotImplementedException();
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