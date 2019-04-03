using System;
using System.Dynamic;

namespace Interfaces
{
    public interface IUser
    {
        int? Id { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime BirthDate { get; set; }
        int Length { get; set; }        
        bool Blocked { get; set; }
        
        IRight Right { get; set; }
    }
}