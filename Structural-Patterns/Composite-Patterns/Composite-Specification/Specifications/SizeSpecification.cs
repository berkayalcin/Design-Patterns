using Composite_Specification.Entity;

namespace Composite_Specification.Specifications
{
    public class SizeSpecification : Specification<Product>
    {
        private Size size;

        public SizeSpecification(Size size)
        {
            this.size = size;
        }

        public override bool IsSatisfied(Product t)
        {
            return t.Size == size;
        }
    }
}