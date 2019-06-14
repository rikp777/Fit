using System;
using System.Collections.Generic;
using System.Linq;
using Data.Contexts.Interfaces;
using Data.Dto;
using Helpers;
using Models;

namespace Data.Contexts.SQLContexts
{
    public class FoodlogContextSQL : IFoodlogContext
    {
        private static List<FoodlogDto> _foodlogs;
        public FoodlogContextSQL()
        {
            InstantiateContextSQL();
        }

        private static void InstantiateContextSQL()
        {
            var dataTable = HelpFunctions.Query("FoodLog_GetAll");
            var foodlogsDto = dataTable.DataTableToList<FoodlogDto>();
            foreach (var foodlogDto in foodlogsDto)
            {
                //var datetime = dataTable.Rows[0]["DateTime"];
                if (new ArticleContextSQL().Read((int) dataTable.Rows[0]["Article_Id"]) != null)
                {
                    foodlogDto.Article = new ArticleContextSQL().Read((int)dataTable.Rows[0]["Article_Id"]);
                }
                else
                {
                    foodlogDto.Dish = new DishContextSQL().Read((int) dataTable.Rows[0]["Dish_Id"]);
                }
                foodlogDto.User = new UserContextSQL().Read((int)dataTable.Rows[0]["User_Id"]);
            }
            _foodlogs = foodlogsDto;
        }
        
        
        
        
        
        public bool Create(IFoodlog foodlog)
        {
            var success = false;
            var parameters = new Dictionary<string, object>
            {
                {"Amount", foodlog.Amount}, 
                {"Unit", foodlog.Unit},
                {"DateTime", foodlog.DateTime},
                {"User_Id", foodlog.User.Id}
            };
            if (foodlog.Article != null)
            {
                parameters.Add("Article_Id", foodlog.Article.Id);
                success = HelpFunctions.nonQuery("Foodlog_InsertArticle", parameters);
            }
            else
            {
                parameters.Add("Dish_Id", foodlog.Dish.Id);
                success = HelpFunctions.nonQuery("Foodlog_InsertDish", parameters);
            }

            InstantiateContextSQL();
            
            return success;
        }
        
        
        
        
        
        public IFoodlog Read(int id)
        {
            var foodlogDto = _foodlogs.FirstOrDefault(f => f.Id == id);

            return foodlogDto;
        }
        public IFoodlog Read(IFoodlog foodlog)
        {
            var foodlogDto = Read(foodlog.Id);

            return foodlogDto;
        }
        public IFoodlog ReadLast(IUser user)
        {
            var foodlogDto = _foodlogs.FirstOrDefault(f => f.User.Id == user.Id);

            return foodlogDto;
        }
        
        
        
        
        
        public bool Update(IFoodlog foodlog)
        {
            var parameters = new Dictionary<string, object>
            {
                {"Id", foodlog.Id},
                {"Amount", foodlog.Amount}, 
                {"Unit", foodlog.Unit},
                {"DateTime", foodlog.DateTime},
                {"User_Id", foodlog.User.Id},
                {"Article_Id", foodlog.Article.Id},
                {"Dish_Id", foodlog.Dish.Id}
            };

            var success = HelpFunctions.nonQuery("Foodlog_Update", parameters);

            InstantiateContextSQL();
            
            return success;
        }
        
        
        
        

        public IEnumerable<IFoodlog> List()
        {
            var foodlogsDto = _foodlogs;

            return foodlogsDto;
        }
        public IEnumerable<IFoodlog> List(IUser user)
        {
            var foodlogsDto = _foodlogs.Where(f => f.User.Id == user.Id);

            return foodlogsDto;
        }
        
        
        


        public bool Delete(int id)
        {
            var parameters = new Dictionary<string, object>
            {
                {"Id", id}
            };

            var success = HelpFunctions.nonQuery("Foodlog_Delete", parameters);

            InstantiateContextSQL();
            
            return success;
        }
    }
}