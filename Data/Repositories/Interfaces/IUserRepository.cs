using System.Collections.Generic;
using Models;

namespace Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IUser GetBy(int id);
        IUser GetBy(string email);



        IEnumerable<IUser> GetAll();



        bool Add(IUser user, string password);
        bool Edit(IUser user);
        bool Delete(int id);



        bool CheckAuth(string email, string password);
    }
}