using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
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
        private readonly NutrientIntakeRepository _nutrientIntakeRepository;

        public ArticleLogic()
        {
            _articleRepository = new ArticleRepository(StorageTypeSetting.Setting);
            _userRepository = new UserRepository(StorageTypeSetting.Setting);
            _nutrientRepository = new NutrientRepository(StorageTypeSetting.Setting);
            _nutrientIntakeRepository = new NutrientIntakeRepository(StorageTypeSetting.Setting);
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
        public bool Add(int UserId, IArticle article)
        {
            if (!UserLogic.CheckRight(UserId, Right.Admin) || UserLogic.CheckRight(UserId, Right.Instructor)) return false;
            
            
            if (_articleRepository.GetBy(article.Name) != null) return false;
            if (!validation(article)) return false;             
            
            
            return _articleRepository.Add(article);
        }
        public bool AddNutrientIntake(int userId, int articleId, INutrientIntake nutrientIntake)
        {
            if (!UserLogic.CheckRight(userId, Right.Admin) || UserLogic.CheckRight(userId, Right.Instructor)) return false;
            var article = _articleRepository.GetBy(articleId);

            if (article.NutrientIntakes != null)
            {
                if(article.NutrientIntakes.Any(a => article.NutrientIntakes.All(n => n.Nutrient.Name == nutrientIntake.Nutrient.Name))) return false; 
            }
            


            return _nutrientIntakeRepository.Add(articleId, nutrientIntake);
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
            if (!UserLogic.CheckRight(userId, Right.Admin) || UserLogic.CheckRight(userId, Right.Instructor)) return false;
            
            
            if (!validation(article)) return false;  
            
            
            return _articleRepository.Edit(article);
        }

        public bool EditNutrientIntake(int userId, int articleId, INutrientIntake nutrientIntake)
        {
            if (!UserLogic.CheckRight(userId, Right.Admin) || UserLogic.CheckRight(userId, Right.Instructor)) return false;
            var article = _articleRepository.GetBy(articleId);
            
            //if(article.NutrientIntakes.Where(a => article.NutrientIntakes.All(n => n.Nutrient.Name == nutrientIntake.Nutrient.Name)) != null) return false;
            //if(article.NutrientIntakes.Any(a => article.NutrientIntakes.All(n => n.Nutrient.Name == nutrientIntake.Nutrient.Name))) return false;


            return _nutrientIntakeRepository.Edit(articleId, nutrientIntake);
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
            if (!UserLogic.CheckRight(userId, Right.Admin) || UserLogic.CheckRight(userId, Right.Instructor)) return false;

            
            if (_articleRepository.GetBy(id) == null) return false;
            
            
            return _articleRepository.Delete(id);
        }

        public bool DeleteNutrientIntake(int userId, int articleId, INutrientIntake nutrientIntake)
        {
            if (!UserLogic.CheckRight(userId, Right.Admin) || UserLogic.CheckRight(userId, Right.Instructor)) return false;
            
            return _nutrientIntakeRepository.Delete(articleId, nutrientIntake);
        }

        
        
        
        
        
        
        
        
        
        
        
        /// <summary>
        ///
        ///     return true when valid
        /// 
        ///     Exception      = 
        ///                    = Calories cant be more than 2000
        ///                    = Name cant be more than 50 
        ///
        /// </summary>
        private bool validation(IArticle article)
        {                          
//            if (!article.NutrientIntakes.Any()) return false;
//            foreach (var nutrientIntake in article.NutrientIntakes)
//            {
//                if (_nutrientRepository.GetBy(nutrientIntake.Nutrient) == null) return false;
//            }
            
            
            if (article.Calories > 2000) return false;
            if (article.Name != null)
            {
                if (article.Name.Length > 50) return false;
            }
            

            
            return true;
        }
    }
}