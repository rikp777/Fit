using System;

namespace Fit.ViewModels.Log
{
    public class LogAddViewModel
    {
        public int ArticleId { get; set; }
        public string ArticleName { get; set; }
        public int Amount { get; set; }
        public string Unit { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
    }
}