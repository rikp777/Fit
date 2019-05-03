using System;
using Models;

namespace Fit.ViewModels.Log
{
    public class LogAddGoalLogViewModel 
    {
        public int Calories { get; set; }
        public DateTime DateTime { get; set; }
        public IUser User { get; set; }
    }
}