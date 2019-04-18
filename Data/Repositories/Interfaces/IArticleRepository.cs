using System.Collections.Generic;
using Models;

namespace Data.Repositories.Interfaces
{
    public interface IArticleRepository
    {
        IArticle GetBy(int id);
        IArticle GetBy(string name);
        IArticle GetBy(IArticle article);
        
        
        
        IEnumerable<IArticle> GetAll();
        
        

        bool Add(IArticle article);
        bool Edit(IArticle article);
        bool Delete(int id);
    }
}