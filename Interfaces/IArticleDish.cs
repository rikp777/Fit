using System.Collections;
using System.Collections.Generic;

namespace Models
{
    public interface IArticleDish
    {
        int Amount { get; }      
        IArticle Article { get; }
    }
}