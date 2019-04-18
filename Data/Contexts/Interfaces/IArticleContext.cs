using System.Collections.Generic;
using Models;

namespace Data.Contexts.Interfaces
{
    public interface IArticleContext
    {     
        bool Create(IArticle article);
        
        
        
        IArticle Read(int id);
        IArticle Read(string name);
        IArticle Read(IArticle article);
        
        
        
        
        bool Update(IArticle article);
        
        
        
        bool Delete(int id);
        
        
        
        IEnumerable<IArticle> List();
        
    }
}