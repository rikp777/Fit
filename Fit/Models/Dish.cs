using System.Collections.Generic;
using Models;

namespace Fit.Models
{
    public class Dish : IDish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<IArticleDish> ArticleDishes { get; set; }
    }
}