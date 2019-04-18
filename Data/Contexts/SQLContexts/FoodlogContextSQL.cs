using System.Collections.Generic;
using Data.Contexts.Interfaces;
using Models;

namespace Data.Contexts.SQLContexts
{
    public class FoodlogContextSQL : IFoodlogContext
    {
        public IFoodlog Read(int id)
        {
            throw new System.NotImplementedException();
        }

        public IFoodlog Read(IFoodlog foodlog)
        {
            throw new System.NotImplementedException();
        }

        public IFoodlog ReadLast(IUser user)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<IFoodlog> List()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<IFoodlog> List(IUser user)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<IFoodlog> ListFromUser(IUser user)
        {
            throw new System.NotImplementedException();
        }

        public bool Create(IFoodlog foodlog)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(IFoodlog foodlog)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}