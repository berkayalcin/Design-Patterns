namespace Composite_Specification.Specifications
{
    public abstract class CompositeSpecification<T> : Specification<T>
    {
        protected readonly Specification<T>[] Specifications;

        public CompositeSpecification(params Specification<T>[] specifications)
        {
            Specifications = specifications;
        }
    }
}