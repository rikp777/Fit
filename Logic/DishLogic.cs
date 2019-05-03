using System.Collections.Generic;
using System.Security.Claims;
using Data.Contexts;
using Data.Repositories;
using Enum;
using Helpers;
using Models;

namespace Logic
{
    public class DishLogic
    {
        private readonly DishRepository _repository;

        public DishLogic()
        {
            _repository = new DishRepository(StorageTypeSetting.Setting);
        }

        
        
        
        
        public IDish GetBy(int id) => _repository.GetBy(id);
        public IDish GetBy(string name) => _repository.GetBy(name);
        public IDish GetBy(IDish dish) => _repository.GetBy(dish);
        
        
        
        
        
        public IEnumerable<IDish> GetAll() => _repository.GetAll();
        
        
        
        
        
        /// <summary>
        /// 
        ///     Create
        ///
        ///     Right    = Admin, Instructor
        ///
        ///     Exception     = validation                   
        /// 
        /// </summary>
        public bool Add(int userId, IDish dish)
        {
            if (!UserLogic.CheckRight(userId, Right.Admin) || UserLogic.CheckRight(userId, Right.Instuctor)) return false;
            
            
            return _repository.Add(dish);
        }
        
        
        
        
        
    }
}