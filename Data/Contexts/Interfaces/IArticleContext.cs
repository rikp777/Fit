using System.Collections.Generic;
using Models;

namespace Data.Contexts.Interfaces
{
    public interface IArticleContext
    {     
        bool Create(IArticle article);
        bool CreateNutrientIntake(int articleId, INutrientIntake newNutrientIntake);
        
        
        IArticle Read(int id);
        IArticle Read(string name);
        IArticle Read(IArticle article);
        
        
        
        
        bool Update(IArticle article);
        bool UpdateNutrientIntake(int articleId, INutrientIntake newNutrientIntake);
        
        
        bool Delete(int id);
        bool DeleteNutrientIntake(int articleId, INutrientIntake newNutrientIntake);
        
        
        IEnumerable<IArticle> List();
        
    }
}