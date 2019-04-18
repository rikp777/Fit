using System.Collections.Generic;
using Models;

namespace Data.Repositories.Interfaces
{
    public interface RightRepository
    {
        IRight GetBy(int id);
        IRight GetBy(string name);
        IRight GetBy(IUser user);


        
        IEnumerable<IRight> GetAll();
    }
}