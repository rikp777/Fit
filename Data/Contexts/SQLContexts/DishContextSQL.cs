using System.Collections.Generic;
using System.Data;
using System.Linq;
using Data.Contexts.Interfaces;
using Data.Dto;
using Helpers;
using Models;

namespace Data.Contexts.SQLContexts
{
    public class DishContextSQL : IDishContext
    {
        private static List<DishDto> _dishes;

        public DishContextSQL()
        {
            InstantiateContextSQL();
        }
        private static void InstantiateContextSQL()
        {
            _dishes = HelpFunctions.Query("Dish_GetAll").DataTableToList<DishDto>();
            foreach (var dish in _dishes)
            {
                var parameters = new Dictionary<string, object> {{"Dish_Id", dish.Id}};
                var dataTable = HelpFunctions.Query("ArticleDish_GetByDishId", parameters);
                var articleDishesDto = new List<ArticleDishDto>();
                foreach (DataRow row in dataTable.Rows)
                {
                    var articleDishDto = new ArticleDishDto
                    {
                        Amount = (int) row["Amount"],
                        Article = new ArticleContextSQL().Read((int) row["Article_Id"])
                    };
                    articleDishesDto.Add(articleDishDto);
                }

                dish.ArticleDishes = articleDishesDto;
            }
        }
        
        
        
        
        
        public bool Create(IDish dish)
        {
            var dishDic = new Dictionary<string, object> {{"Name", dish.Name}};

            var success = HelpFunctions.nonQuery("Dish_Insert", dishDic);
            
            
            if (success)
            {
                foreach (var dishData in dish.ArticleDishes)
                {
                    var articleDishDic = new Dictionary<string, object>();
                    articleDishDic.Add("Amount", dishData.Amount); 
                    articleDishDic.Add("Article_Id", dishData.Article.Id);
                    articleDishDic.Add("Dish_Id", Read(dish));
                    HelpFunctions.nonQuery("ArticleDish_Insert", articleDishDic);
                }
            }

            InstantiateContextSQL();

            return success;
        }

        public IDish Read(int id)
        {
            var dishDto = _dishes.FirstOrDefault(d => d.Id == id);
            
            return dishDto;
        }
        public IDish Read(string name)
        {
            var dishDto = _dishes.FirstOrDefault(d => d.Name == name);
            
            return dishDto;
        }
        public IDish Read(IDish dish)
        {
            var dishDto = Read(dish.Id);
            
            return dishDto;
        }
        
        
        
        
       
        public bool Update(IDish dish)
        {
            var parameters = new Dictionary<string, object>
            {
                {"Id", dish.Id}, 
                {"Name", dish.Name}
            };
            
            InstantiateContextSQL();

            return HelpFunctions.nonQuery("Dish_Update", parameters);
        }
        
        
        

        
        public bool Delete(int id)
        {
            var parameters = new Dictionary<string, object>
            {
                {"Id", id}
            };
            
            InstantiateContextSQL();

            return HelpFunctions.nonQuery("Dish_Delete", parameters);
        }

        
        
        
        
        public IEnumerable<IDish> List()
        {
            var dishesDto = _dishes;

            return dishesDto;
        }
    }
}