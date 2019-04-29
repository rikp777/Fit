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
    public class NutrientIntakeRepository : INutrientIntakeRepository
    {
        private readonly IArticleContext _context;

        public NutrientIntakeRepository(StorageTypeSetting.StorageTypes storageType)
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
                    throw new ArgumentOutOfRangeException(nameof(storageType), storageType, "Set Storage Type");
            }
        }
    
        
        
        public bool Add(int articleId, INutrientIntake nutrientIntake) => _context.CreateNutrientIntake(articleId, nutrientIntake);
        public bool Edit(int articleId, INutrientIntake nutrientIntake) => _context.UpdateNutrientIntake(articleId, nutrientIntake);
        public bool Delete(int articleId, INutrientIntake NutrientIntake) => _context.DeleteNutrientIntake(articleId, NutrientIntake);
    }
}