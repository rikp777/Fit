using System.ComponentModel;
using Logic.Models;

namespace Fit.ViewModels.Auth
{
    public class LoginViewModel
    {
        [DisplayName("Email:")]
        public string Email { get; set; }

        [DisplayName("Password:")]
        public string Password { get; set; }  
        
        public Message Message { get; set; }         
    }
}