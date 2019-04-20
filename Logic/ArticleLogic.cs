using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Data.Contexts;
using Data.Contexts.Interfaces;
using Data.Contexts.SQLContexts;
using Data.Repositories;
using Enum;
using Models;

namespace Logic
{
    public class ArticleLogic
    {
        private readonly ArticleRepository _articleRepository;
        private readonly UserRepository _userRepository;
        private readonly NutrientRepository _nutrientRepository;

        public ArticleLogic()
        {
            _articleRepository = new ArticleRepository(StorageTypeSetting.Setting);
            _userRepository = new UserRepository(StorageTypeSetting.Setting);
            _nutrientRepository = new NutrientRepository(StorageTypeSetting.Setting);
        }
   
        
       
        
        
        public IArticle GetBy(int id) => _articleRepository.GetBy(id);
        public IArticle GetBy(string name) => _articleRepository.GetBy(name);
        public IArticle GetBy(IArticle article) => _articleRepository.GetBy(article);
        
        
        
        
        
        public IEnumerable<IArticle> GetAll() => _articleRepository.GetAll();


        
        

        /// <summary>
        /// 
        ///     Create
        ///
        ///     Right    = Admin, Instructor
        ///
        ///     Exception     = validation                   
        /// 
        /// </summary>
        public bool Add(int userId, IArticle article)
        {
            if (!CheckRight(userId, Right.Admin)) return false;
            if (!CheckRight(userId, Right.Instuctor)) return false;
            
            
            if (!validation(article)) return false;                   
            
            
            return _articleRepository.Add(article);
        }

        

        
        /// <summary>
        /// 
        ///     Update
        ///
        ///     Right    = Admin, Instructor
        ///
        ///     Exception     = validation                   
        /// 
        /// </summary>
        public bool Edit(int userId, IArticle article)
        {
            if (!CheckRight(userId, Right.Admin)) return false;
            if (!CheckRight(userId, Right.Instuctor)) return false;
            
            
            if (!validation(article)) return false;  
            
            
            return _articleRepository.Edit(article);
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
            if (!CheckRight(userId, Right.Admin)) return false;
            if (!CheckRight(userId, Right.Instuctor)) return false;

            if (_articleRepository.GetBy(id) == null) return false;
            
            
            return _articleRepository.Delete(id);
        } 

        
        
        
        
        
        
        
        
        
        
        
        /// <summary>
        ///
        ///     return true when valid
        /// 
        ///     Exception      = No Duplicates by name
        ///                    = Nutrient cant be null
        ///                    = Nutrients must exist 
        ///
        ///                    = Calories cant be more than 2000
        ///                    = Name cant be more than 50 
        ///
        /// </summary>
        private bool validation(IArticle article)
        {
            var articleData = _articleRepository.GetBy(article);            
            
            
            if (articleData.Name == article.Name) return false;
            if (!article.NutrientIntakes.Any()) return false;
            foreach (var nutrientIntake in article.NutrientIntakes)
            {
                if (_nutrientRepository.GetBy(nutrientIntake.Nutrient) == null) return false;
            }
            
            
            if (article.Calories > 2000) return false;
            if (article.Name.Length > 50) return false;

            
            return true;
        }

        /// returns true when valid 
        private bool CheckRight(int id, Right right)
        {
            var UserData = _userRepository.GetBy(id);

            
            if (UserData.Right.Name == right.ToString()) return true;

            
            return false;
        }
    }
}