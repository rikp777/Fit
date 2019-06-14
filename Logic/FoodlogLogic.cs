using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using Data.Contexts;
using Data.Repositories;
using Models;

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
        
        
        
        
        /// <summary>
        /// 
        ///     Update
        ///
        ///     Right    = All
        ///
        ///     Exception     = Foodlog.Article cant be null
        ///
        /// </summary>
        public bool Add(int userId, IFoodlog foodlog)
        {
            if (foodlog.Dish != null || foodlog.Article != null)
            {
                return _repository.Add(foodlog);
            }
            return false;
        }
    }
}