using System.Collections;
using System.Collections.Generic;

namespace Models
{
    public interface IDish
    {
        int Id { get; }
        string Name { get; }
        IEnumerable<IArticleDish> ArticleDishes { get;}
    }
}