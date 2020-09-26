using Composite_Specification.Entity;

namespace Composite_Specification.Specifications
{
    public class ColorSpecification : Specification<Product>
    {
        private Color color;

        public ColorSpecification(Color color)
        {
            this.color = color;
        }

        public override bool IsSatisfied(Product t)
        {
            return t.Color == color;
        }
    }
}