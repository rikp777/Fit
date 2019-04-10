using System.Collections.Generic;
using Data.Contexts;
using Data.Contexts.Interfaces;
using Data.Contexts.MemoryContexts;
using Data.Contexts.SQLContexts;
using Interfaces;

namespace Data.Repositories
{
    public class ArticleRepository
    {
        private readonly IArticleContext _context;

        public ArticleRepository(StorageTypeSetting.StorageTypes storageType)
        {
            switch (storageType)
            {
                case StorageTypeSetting.StorageTypes.SQL :
                    _context = new ArticleContextSQL();   
                    break;
                default: 
                    _context = new ArticleContextMemory();    
                    break; 
            }
        }

        public IArticle GetBy(int id)
        {
            IArticle article = _context.Read(id);
            
            if (article == null) { return null; }
            
            return article;
        }

        public IArticle GetBy(string name)
        {
            IArticle article = _context.Read(name);
            
            if (article == null) { return null; }
            
            return article;
        }
        public IEnumerable<IArticle> GetAll()
        {
            return _context.List();
        }
        public bool Add(IArticle article)
        {
            return _context.Create(article);
        }

        public bool Edit(IArticle article)
        {
            return _context.Update(article);
        }

        public bool Delete(int id)
        {
            return _context.Delete(id);
        }
    }
}