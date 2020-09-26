using System;

namespace Static_Decorator_Compasition
{
    public class TransparentShape<T> : Shape
        where T : Shape, new()
    {
        private float _transparency;
        private T _shape = new T();

        public TransparentShape() : this(0.0f)
        {
        }

        public TransparentShape(float ratio)
        {
            _transparency = ratio;
        }

        public override string AsString()
        {
            return $"{_shape.AsString()} Has the Transparency {_transparency % 100.0f}%";
        }
    }

    public class TransparentShape : Shape
    {
        private Shape _shape;
        private float _transparency;

        public TransparentShape(float transparency, Shape shape)
        {
            _transparency = transparency;
            _shape = shape ?? throw new ArgumentNullException(nameof(shape));
        }

        public override string AsString()
        {
            return $"{_shape.AsString()} Has Transparency {_transparency % 100.0}%";
        }
    }
}