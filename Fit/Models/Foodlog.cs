using System;
using Enum;
using Models;

namespace Fit.Models
{
    public class Foodlog
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public DateTime DateTime { get; set; }
        public Article Article { get; set; }
        public User User { get; set; }
        public Unit Unit { get; set; }
    }
}