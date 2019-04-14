using System.Collections.Generic;
using Interfaces;

namespace Fit.ViewModels.User
{
    public class UserDashBoardViewModel
    {
        public IEnumerable<IFoodlog> FoodlogsBreakfast { get; set; }
        public IEnumerable<IFoodlog> FoodlogsLunch { get; set; }
        public IEnumerable<IFoodlog> FoodlogsSupper { get; set; }
    }
}