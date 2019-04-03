using System;
using System.Collections.Generic;
using Interfaces;

namespace Data.Contexts.Interfaces
{
    public interface IUserContext
    {
        IUser Read(int id);
        IUser Read(string email);
        List<IUser> List();
        bool Create(IUser user);
        bool Update(IUser user);
        bool Delete(int id);
    }
}