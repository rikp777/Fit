using System;
using Interfaces;

namespace Logic.Models
{
    public class User : IUser
    {
        public int? Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int Length { get; set; }
        public bool Blocked { get; set; }
        public IRight Right { get; set; }
    }
}