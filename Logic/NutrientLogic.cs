using System;
using System.Collections.Generic;
using Data.Contexts;
using Data.Repositories;
using Enum;
using Models;

namespace Logic
{
    public class NutrientLogic
    {
        private readonly NutrientRepository _nutrientRepository;
        private readonly UserRepository _userRepository;

        public NutrientLogic()
        {
            _nutrientRepository = new NutrientRepository(StorageTypeSetting.Setting);
            _userRepository = new UserRepository(StorageTypeSetting.Setting);
        }
        
        
        
        
        
        public INutrient GetBy(int id) => _nutrientRepository.GetBy(id);
        public INutrient GetBy(string name) => _nutrientRepository.GetBy(name);
        public INutrient GetBy(INutrient nutrient) => _nutrientRepository.GetBy(nutrient);
        
        
        
        
        public IEnumerable<INutrient> GetAll() => _nutrientRepository.GetAll();



        
        /// <summary>
        /// 
        ///     Create
        ///
        ///     Right    = Admin, Instructor
        ///
        ///     Exception     = validation                   
        /// 
        /// </summary>
        public bool Add(int userId, INutrient nutrient)
        {
            if (!CheckRight(userId, Right.Admin) || CheckRight(userId, Right.Instuctor)) return false;
            
            
            if (_nutrientRepository.GetBy(nutrient.Name) != null) return false;
            if (!validation(nutrient)) return false;  
            

            return _nutrientRepository.Add(nutrient);
        }
        
        
        
        
        /// <summary>
        /// 
        ///     Create
        ///
        ///     Right    = Admin, Instructor
        ///
        ///     Exception     = validation                   
        /// 
        /// </summary>
        public bool Edit(int userId, INutrient nutrient)
        {
            if (!CheckRight(userId, Right.Admin) || CheckRight(userId, Right.Instuctor)) return false;
            
            
            if (!validation(nutrient)) return false;  
            

            return _nutrientRepository.Edit(nutrient);
        }
        
        
        
        
        /// <summary>
        /// 
        ///     Delete
        ///
        ///     Right    = Admin, Instructor
        ///
        ///     Exception        = Must exist 
        ///                    
        /// </summary>
        public bool Delete(int userId, int id)
        {
            if (!CheckRight(userId, Right.Admin) || CheckRight(userId, Right.Instuctor)) return false;

            
            if (_nutrientRepository.GetBy(id) == null) return false;
            
            
            return _nutrientRepository.Delete(id);
        }
        
        
        
        
        
        
        
            
        // <summary>
        ///
        ///     return true when valid
        /// 
        ///     Exception      = 
        ///                    = maxintake cant be more than 2000
        ///                    = Name cant be more than 50 
        ///
        /// </summary>
        private bool validation(INutrient nutrient)
        {
            if (nutrient.MaxIntake > 2000) return false;
            if (nutrient.Name.Length > 50) return false;
            
            
            return true;
        }
        
        /// returns true when valid 
        private bool CheckRight(int id, Right right)
        {
            var UserData = _userRepository.GetBy(id);
           
            return UserData.Right.Name == right.ToString();
        }
    }
}