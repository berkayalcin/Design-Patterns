using System;
using System.Linq;

namespace Composite_Specification.Specifications
{
    // Combinator
    public class AndSpecification<T> : CompositeSpecification<T>
    {
        public AndSpecification(params Specification<T>[] specifications) : base(specifications)
        {
        }

        public override bool IsSatisfied(T t)
        {
            return Specifications.All(specification => specification.IsSatisfied(t));
        }
    }
}