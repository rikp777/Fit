using System;
using Models;

namespace Fit.ViewModels.Log
{
    public class LogAddWeightLogViewModel
    {
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public decimal Weight { get; set; }
        public IUser User { get; set; }
    }
}