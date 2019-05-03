using System.Collections.Generic;
using Data.Contexts.Interfaces;
using Data.Dto;
using Helpers;
using Models;

namespace Data.Contexts.SQLContexts
{
    public class DishContextSQL : IDishContext
    {
        public bool Create(IDish dish)
        {
            throw new System.NotImplementedException();
        }

        public IDish Read(int id)
        {
            throw new System.NotImplementedException();
        }

        public IDish Read(string name)
        {
            throw new System.NotImplementedException();
        }

        public IDish Read(IDish dish)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(IDish dish)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<IDish> List()
        {
            var data = HelpFunctions.Query("Dish_GetAll");
            var dishes = data.DataTableToList<DishDto>();
            return dishes;
        }
    }
}