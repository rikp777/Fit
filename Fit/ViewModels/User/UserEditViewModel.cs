using System;
using System.Collections.Generic;
using Logic.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;

namespace Fit.ViewModels.User
{
    public class UserEditViewModel : IUser
    {       
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