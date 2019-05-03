using System;
using Models;

namespace Data.Dto
{
    public class WeightlogDto : IWeightlog
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Weight { get; set; }
        public IUser User { get; set; }
    }
}