using System;

namespace Dynamic_Decorator_Composition
{
    public interface IShape
    {
        string AsString();
    }

    public class Square : IShape
    {
        private float _side;

        public Square(float side)
        {
            _side = side;
        }

        public string AsString()
        {
            return $"A Square with side {_side}";
        }
    }

    public class Circle : IShape
    {
        private float _radius;

        public Circle(float radius)
        {
            _radius = radius;
        }

        public void Resize(float factor)
        {
            _radius *= factor;
        }

        public string AsString() => $"A Circle with radius {_radius}";
    }

    public class ColoredShape : IShape
    {
        private IShape _shape;
        private string _color;

        public ColoredShape(IShape shape, string color)
        {
            _shape = shape ?? throw new ArgumentNullException(nameof(shape));
            _color = color ?? throw new ArgumentNullException(nameof(color));
        }

        public string AsString()
        {
            return $"{_shape.AsString()} Has the color {_color}";
        }
    }

    public class TransparentShape : IShape
    {
        private IShape _shape;
        private float _transparency;

        public TransparentShape(float transparency, IShape shape)
        {
            _transparency = transparency;
            _shape = shape ?? throw new ArgumentNullException(nameof(shape));
        }

        public string AsString()
        {
            return $"{_shape.AsString()} Has Transparency {_transparency % 100.0}%";
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var square = new Square(1.23f);
            Console.WriteLine(square.AsString());

            var redSquare = new ColoredShape(square, "Red");
            Console.WriteLine(redSquare.AsString());

            var transparentSquare = new TransparentShape(50f, redSquare);
            Console.WriteLine(transparentSquare.AsString());
        }
    }
}