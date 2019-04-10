using System.Collections.Generic;
using Interfaces;

namespace Data.Contexts.Interfaces
{
    public interface IArticleContext
    {
        IArticle Read(int id);
        IArticle Read(string name);
        IEnumerable<IArticle> List();
        bool Create(IArticle article);
        bool Update(IArticle article);
        bool Delete(int id);
    }
}