using System.Collections.Generic;
using Data.Contexts;
using Data.Repositories;
using Models;

namespace Logic
{
    public class RightLogic
    {
        private readonly RightRepository _repository;

        public RightLogic()
        {
            _repository = new RightRepository(StorageTypeSetting.Setting);
        }

       
        
        
        public IRight GetBy(int id) => _repository.GetBy(id);
        public IRight GetBy(string name) => _repository.GetBy(name);
        
        
        
        
        public IEnumerable<IRight> GetAll() => _repository.GetAll();
    }
}