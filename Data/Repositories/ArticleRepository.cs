using System;
using System.Collections.Generic;
using Data.Contexts;
using Data.Contexts.Interfaces;
using Data.Contexts.MemoryContexts;
using Data.Contexts.SQLContexts;
using Data.Repositories.Interfaces;
using Models;

namespace Data.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly IArticleContext _context;

        public ArticleRepository(StorageTypeSetting.StorageTypes storageType)
        {
            switch (storageType)
            {
                case StorageTypeSetting.StorageTypes.SQL :
                    _context = new ArticleContextSQL();   
                    break;
                case StorageTypeSetting.StorageTypes.Memory:
                    _context = new ArticleContextMemory();    
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(storageType), storageType, "Set storage type");
            }
        }




        public IArticle GetBy(int id) => _context.Read(id);
        public IArticle GetBy(string name) => _context.Read(name);
        public IArticle GetBy(IArticle article) => _context.Read(article);




        public IEnumerable<IArticle> GetAll() => _context.List();




        public bool Add(IArticle article) => _context.Create(article);
        public bool Edit(IArticle article) => _context.Update(article);
        public bool Delete(int id) => _context.Delete(id);
    }
}