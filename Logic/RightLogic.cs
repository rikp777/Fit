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

        public List<IRight> Rights => _repository.GetAll();
    }
}