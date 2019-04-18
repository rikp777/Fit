using System;
using System.Collections.Generic;
using Models;

namespace Data.Contexts.Interfaces
{
    public interface IUserContext
    {
        bool Create(IUser user, string password);
        
        
        
        IUser Read(int id);
        IUser Read(string email);
        IUser Read(IUser user);
        
        
        
        bool Update(IUser user);
        
        
        
        bool Delete(int id);
        
        
        
        IEnumerable<IUser> List();
        
        
        
        bool Auth(string email, string password);
    }
}