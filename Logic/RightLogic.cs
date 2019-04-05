using System.Collections.Generic;
using Data.Contexts;
using Data.Repositories;
using Interfaces;
using Logic.Models;

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
    }
}