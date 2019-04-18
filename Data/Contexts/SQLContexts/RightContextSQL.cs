using System.Collections.Generic;
using Data.Contexts.Interfaces;
using Models;

namespace Data.Contexts.SQLContexts
{
    public class RightContextSQL : IRightContext
    {
        public IRight Read(int id)
        {
            throw new System.NotImplementedException();
        }

        public IRight Read(string name)
        {
            throw new System.NotImplementedException();
        }

        public IRight Read(IUser user)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<IRight> List()
        {
            throw new System.NotImplementedException();
        }
    }
}