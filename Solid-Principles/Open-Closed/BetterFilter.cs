using System.Collections.Generic;
using System.Linq;

namespace Solid_Principles
{
    public class BetterFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> specification)
        {
            return items.Where(specification.IsSatisfied);
        }
    }
}