using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using Data.Contexts.Interfaces;
using Models;

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

        public IUser Read(IUser user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IUser> List()
        {
            throw new System.NotImplementedException();
        }

        public bool Auth(string email, string password)
        {
            throw new NotImplementedException();
        }

        public bool Create(IUser user, string password)
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