using System;
using Models;

namespace Fit.Models
{
    public class WeightLog : IWeightlog
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Weight { get; set; }
        public IUser User { get; set; }
    }
}