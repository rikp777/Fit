using System;
using System.Collections.Generic;
using Interfaces;

namespace Fit.ViewModels.Article
{
    public class ArticleListViewModel
    {
        public IEnumerable<IArticle> AllArticles { get; set; }
    }
}