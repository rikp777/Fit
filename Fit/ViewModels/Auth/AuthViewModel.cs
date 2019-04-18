using System;
using System.ComponentModel.DataAnnotations;
using Models;

namespace Fit.ViewModels.Auth
{
    public class AuthViewModel : IUser
    {
        [Required]
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int Length { get; set; }
        public bool Blocked { get; set; }
        public IRight Right { get; set; }
    }
}