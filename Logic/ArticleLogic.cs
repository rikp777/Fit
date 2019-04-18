using System.Collections.Generic;
using Data.Contexts;
using Data.Repositories;
using Models;

namespace Logic
{
    public class ArticleLogic
    {
        private readonly ArticleRepository _repository;

        public ArticleLogic()
        {
            _repository = new ArticleRepository(StorageTypeSetting.Setting);
        }
        
        
        
        
        
        public IArticle GetBy(int id) => _repository.GetBy(id);
        
        
        
        
        
        public IEnumerable<IArticle> GetAll() => _repository.GetAll();
  
        
        
        
        
        public bool Delete(int id) => _repository.Delete(id);
    }
}