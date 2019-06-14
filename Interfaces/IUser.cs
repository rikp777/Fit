using System;

namespace Models
{
    public interface IUser
    {
        int Id { get; }
        string Email { get; }
        string FirstName { get; }
        string LastName { get; }
        DateTime BirthDate { get; }
        int Length { get; }        
        bool Blocked { get; }
        
        IRight Right { get; }
    }
}