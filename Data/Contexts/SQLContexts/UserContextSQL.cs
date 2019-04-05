using System;
using System.Collections.Generic;
using Data.Contexts.Interfaces;
using Data.dto;
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

        public IEnumerable<IUser> List()
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

        public UserDto Auth(string email)
        {
            throw new System.NotImplementedException();
        }
    }
}