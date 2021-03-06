using System;
using System.Collections.Generic;
using Models;

namespace Data.Contexts.Interfaces
{
    public interface IRightContext
    {
        IRight Read(int id);
        IRight Read(string name);
        IRight Read(IUser user);
               
        
        
        IEnumerable<IRight> List();
    }
}