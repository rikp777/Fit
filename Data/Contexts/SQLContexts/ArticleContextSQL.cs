using System.Collections.Generic;
using Data.Contexts.Interfaces;
using Models;

namespace Data.Contexts.SQLContexts
{
    public class ArticleContextSQL : IArticleContext
    {
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

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}