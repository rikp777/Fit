using System.Collections.Generic;
using Models;

namespace Data.Dto
{
    public class ArticleDishDto : IArticleDish
    {
        public int Amount { get; set; }
        public IArticle Article { get; set; }

    }
}