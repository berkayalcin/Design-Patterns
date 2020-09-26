using System.Linq;

namespace Composite_Specification.Specifications
{
    public class OrSpecification<T> : CompositeSpecification<T>
    {
        public OrSpecification(params Specification<T>[] specifications) : base(specifications)
        {
        }

        public override bool IsSatisfied(T t)
        {
            return Specifications.Any(specification => specification.IsSatisfied(t));
        }
    }
}