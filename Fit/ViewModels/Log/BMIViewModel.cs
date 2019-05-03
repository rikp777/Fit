using System;
using Models;

namespace Fit.ViewModels.Log
{
    public class BMIViewModel
    {
        public decimal Weight { get; set; }
        public int Lenght { get; set; }
        public decimal BMI { get; set; }
        public DateTime DateTime { get; set; }
    }
}