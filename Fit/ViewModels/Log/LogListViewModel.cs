using System.Collections.Generic;
using Fit.Models;
using Models;

namespace Fit.ViewModels.Log
{
    public class LogListViewModel
    {
        public IEnumerable<Foodlog> FoodlogsBreakfast { get; set; }
        public IEnumerable<Foodlog> FoodlogsLunch { get; set; }
        public IEnumerable<Foodlog> FoodlogsSupper { get; set; }
    }
}