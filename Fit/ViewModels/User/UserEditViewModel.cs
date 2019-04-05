using System;
using System.Collections.Generic;
using Interfaces;
using Logic.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fit.ViewModels.User
{
    public class UserEditViewModel
    {       
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int Length { get; set; }
        public Right Right { get; set; }
    }
}