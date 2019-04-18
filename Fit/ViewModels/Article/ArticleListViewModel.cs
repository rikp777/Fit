using System;
using System.Collections.Generic;
using Models;

namespace Fit.ViewModels.Article
{
    public class ArticleListViewModel
    {
        public IEnumerable<IArticle> AllArticles { get; set; }
    }
}