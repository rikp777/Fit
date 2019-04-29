using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;

namespace Fit.ViewModels.Article
{
    public class ArticleAddViewModel
    {
        public string Name { get; set; }
        public int Calories { get; set; }
    }
}