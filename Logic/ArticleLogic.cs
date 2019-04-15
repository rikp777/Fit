using System.Collections.Generic;
using Data.Contexts;
using Data.Repositories;
using Interfaces;

namespace Logic
{
    public class ArticleLogic
    {
        private readonly ArticleRepository _repository;

        public ArticleLogic()
        {
            _repository = new ArticleRepository(StorageTypeSetting.Setting);
        }
        public IEnumerable<IArticle> GetAll() => _repository.GetAll();
        public IArticle GetBy(int id) => _repository.GetBy(id);
    }
}