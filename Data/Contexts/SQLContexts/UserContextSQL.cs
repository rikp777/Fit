using System.Collections.Generic;
using Data.Contexts.Interfaces;
using Interfaces;

namespace Data.Contexts.SQLContexts
{
    public class UserContextSQL : IUserContext
    {
        public IUser Read(int id)
        {
            throw new System.NotImplementedException();
        }

        public IUser Read(string email)
        {
            throw new System.NotImplementedException();
        }

        public List<IUser> List()
        {
            throw new System.NotImplementedException();
        }

        public bool Create(IUser user)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(IUser user)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}