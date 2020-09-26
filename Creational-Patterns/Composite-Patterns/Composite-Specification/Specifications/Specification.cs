namespace Composite_Specification.Specifications
{
    public abstract class Specification<T>
    {
        public abstract bool IsSatisfied(T t);

        public static Specification<T> operator &(Specification<T> first, Specification<T> second)
        {
            return new AndSpecification<T>(first, second);
        }

        public static Specification<T> operator |(Specification<T> first, Specification<T> second)
        {
            return new OrSpecification<T>(first, second);
        }
    }
}