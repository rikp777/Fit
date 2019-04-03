using System;
using System.Collections.Generic;
using Interfaces;

namespace Data.Contexts.Interfaces
{
    public interface IRightContext
    {
        IRight Read(int id);
        IRight Read(string name);
        IRight Read(IUser user);
        List<IRight> List();
    }
}