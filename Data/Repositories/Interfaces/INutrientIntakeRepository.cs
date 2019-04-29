using System.Collections.Generic;
 using Models;
 
 namespace Data.Repositories.Interfaces
 {
     public interface INutrientIntakeRepository
     {
         bool Add(int articleId, INutrientIntake nutrientIntake);
         bool Edit(int articleId, INutrientIntake nutrientIntake);
         bool Delete(int articleId, INutrientIntake NutrientIntake);
     }
 }