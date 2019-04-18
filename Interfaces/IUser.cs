using System;

namespace Models
{
    public interface IUser
    {
        int Id { get; set; }
        string Email { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime BirthDate { get; set; }
        int Length { get; set; }        
        bool Blocked { get; }
        
        IRight Right { get; }
    }
}