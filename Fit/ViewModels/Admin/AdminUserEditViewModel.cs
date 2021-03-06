using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fit.ViewModels.Admin
{
    public class AdminUserEditViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int Length { get; set; }
        public bool Blocked { get; set; }
        public int Right { get; set; }
              
        public IEnumerable<SelectListItem> Rights { get; set; }
    }
}