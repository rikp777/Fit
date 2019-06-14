using System;
using Enum;
using Models;

namespace Data.Dto
{
    public class FoodlogDto : IFoodlog
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public DateTime DateTime { get; set; }
        public IArticle Article { get; set; }
        public IDish Dish { get; set; }
        public IUser User { get; set; }
        public Unit Unit { get; set; }
    }
}