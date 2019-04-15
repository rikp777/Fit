using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using Data.Contexts;
using Data.Repositories;
using Interfaces;

namespace Logic
{
    public class FoodlogLogic
    {
        private readonly FoodlogRepository _repository;

        public FoodlogLogic()
        {
            _repository = new FoodlogRepository(StorageTypeSetting.Setting);
        }

        public IFoodlog GetBy(int id) => _repository.GetBy(id);
        public IEnumerable<IFoodlog> GetAll() => _repository.GetAll();
        public IEnumerable<IFoodlog> GetAllBy(IUser user) => _repository.GetAllBy(user);
        public bool Add(IFoodlog foodlog) => _repository.Add(foodlog);
    }
}