using System;
using System.ComponentModel.DataAnnotations;

namespace Fit.ViewModels.Auth
{
    public class RegisterViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public int Length { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PasswordH { get; set; }
    }
}