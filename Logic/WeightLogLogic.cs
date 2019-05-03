using System.Collections;
using System.Collections.Generic;
using Data.Contexts;
using Data.Repositories;
using Models;

namespace Logic
{
    public class WeightLogLogic
    {
        private readonly WeightLogRepository _weightLogRepository;

        public WeightLogLogic()
        {
            _weightLogRepository = new WeightLogRepository(StorageTypeSetting.Setting);
        }




        public IWeightlog GetBy(int id) => _weightLogRepository.GetBy(id);




        public IEnumerable<IWeightlog> GetAll() => _weightLogRepository.GetAll();
        public IEnumerable<IWeightlog> GetAllBy(IUser user) => _weightLogRepository.GetAllBy(user);




        public bool Add(int userId, IWeightlog weightlog)
        {
            return _weightLogRepository.Add(weightlog);
        }
    }
}