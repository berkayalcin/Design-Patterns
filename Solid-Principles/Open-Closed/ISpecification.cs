namespace Solid_Principles
{
    public interface ISpecification<T>
    {
        bool IsSatisfied(T t);
    }
}