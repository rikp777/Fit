using System.Collections.Generic;
using Data.Contexts.Interfaces;
using Models;

namespace Data.Contexts.SQLContexts
{
    public class NutrientContextSql : INutrientContext
    {
        public bool Create(INutrient nutrient)
        {
            throw new System.NotImplementedException();
        }

        public INutrient Read(int id)
        {
            throw new System.NotImplementedException();
        }

        public INutrient Read(string name)
        {
            throw new System.NotImplementedException();
        }

        public INutrient Read(INutrient nutrient)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(INutrient nutrient)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<INutrient> List()
        {
            throw new System.NotImplementedException();
        }
    }
}