using System.Collections.Generic;
using Data.Contexts.Interfaces;
using Interfaces;

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

        public List<IRight> List()
        {
            throw new System.NotImplementedException();
        }
    }
}