using System.Collections.Generic;
using Composite_Specification.Specifications;

namespace Composite_Specification
{
    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, Specification<T> specification);
    }
}