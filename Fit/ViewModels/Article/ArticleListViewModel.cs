using System;
using System.Collections;
using System.Collections.Generic;
using Models;

namespace Fit.ViewModels.Article
{
    public class ArticleListViewModel
    {
        public IEnumerable<IArticle> AllArticles { get; set; }
        public IEnumerable<IDish> AllDishes { get; set; }
    }
}