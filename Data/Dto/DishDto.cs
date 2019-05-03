using System.Collections.Generic;
using Models;

namespace Data.Dto
{
    public class DishDto : IDish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<IArticleDish> ArticleDishes { get; set; }
    }
}