using System.Collections.Generic;
using Data.Contexts;
using Data.Repositories;
using Interfaces;

namespace Logic
{
    public class RightLogic
    {
        private readonly RightRepository _repository;

        public RightLogic()
        {
            _repository = new RightRepository(StorageTypeSetting.Setting);
        }

        public List<IRight> GetAll() => _repository.GetAll();
        public IRight GetBy(int id) => _repository.GetBy(id);
        public IRight GetBy(string name) => _repository.GetBy(name);
    }
}