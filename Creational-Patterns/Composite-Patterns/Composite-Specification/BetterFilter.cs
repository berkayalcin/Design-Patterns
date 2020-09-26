using System.Collections.Generic;
using System.Linq;
using Composite_Specification.Entity;
using Composite_Specification.Specifications;

namespace Composite_Specification
{
    public class BetterFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, Specification<Product> specification)
        {
            return items.Where(specification.IsSatisfied);
        }
    }
}