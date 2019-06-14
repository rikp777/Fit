using System.Collections.Generic;
using Models;

namespace Fit.Models
{
    public class ArticleDish : IArticleDish
    {
        public int Amount { get; set; }
        public IArticle Article { get; set; }
    }
}