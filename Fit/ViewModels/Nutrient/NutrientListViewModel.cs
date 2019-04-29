using System.Collections.Generic;
using Models;

namespace Fit.ViewModels.Nutrient
{
    public class NutrientListViewModel
    {
        public IEnumerable<INutrient> AllNutrients { get; set; }
    }
}