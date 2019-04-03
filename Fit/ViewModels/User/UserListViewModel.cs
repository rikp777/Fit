using System.Collections.Generic;
using Fit.ViewModels.Auth;
using Interfaces;

namespace Fit.ViewModels.User
{
    public class UserListViewModel
    {
        public List<IUser> AllUsers { get; set; }
    }
}