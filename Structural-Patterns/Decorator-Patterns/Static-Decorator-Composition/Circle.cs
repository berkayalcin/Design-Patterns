namespace Static_Decorator_Compasition
{
    public class Circle : Shape
    {
        private float _radius;

        public Circle() : this(0.0f)
        {
        }

        public Circle(float radius)
        {
            _radius = radius;
        }

        public void Resize(float factor)
        {
            _radius *= factor;
        }

        public override string AsString() => $"A Circle with radius {_radius}";
    }
}