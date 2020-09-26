using System;

namespace Static_Decorator_Compasition
{
    public class ColoredShape<T> : Shape
        where T : Shape, new()
    {
        private string _color;
        private T _shape = new T();

        public ColoredShape() : this("black")
        {
        }

        public ColoredShape(string color)
        {
            _color = color;
        }


        public override string AsString()
        {
            return $"{_shape.AsString()} Has the color {_color}";
        }
    }

    public class ColoredShape : Shape
    {
        private Shape _shape;
        private string _color;

        public ColoredShape(Shape shape, string color)
        {
            _shape = shape ?? throw new ArgumentNullException(nameof(shape));
            _color = color ?? throw new ArgumentNullException(nameof(color));
        }

        public override string AsString()
        {
            return $"{_shape.AsString()} Has the color {_color}";
        }
    }
}