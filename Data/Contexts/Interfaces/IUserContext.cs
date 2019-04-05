using System;
using System.Collections.Generic;
using Data.dto;
using Interfaces;

namespace Data.Contexts.Interfaces
{
    public interface IUserContext
    {
        IUser Read(int id);
        IUser Read(string email);
        IEnumerable<IUser> List();
        bool Create(IUser user);
        bool Update(IUser user);
        bool Delete(int id);
        UserDto Auth(string email);
    }
}