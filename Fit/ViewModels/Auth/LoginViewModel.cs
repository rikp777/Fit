using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Logic.Models;

namespace Fit.ViewModels.Auth
{
    public class LoginViewModel
    {
        [Required]
        [DisplayName("Email:")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Password:")]
        public string Password { get; set; }  
        
        public Message Message { get; set; }         
    }
}