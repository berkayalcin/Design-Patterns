using System;
using Autofac;

namespace Bridge
{
    public interface IRenderer
    {
        void RenderCircle(float radius);
    }

    public class RasterRenderer : IRenderer
    {
        public void RenderCircle(float radius)
        {
            Console.WriteLine($"Drawing pixels for circle with radius {radius}");
        }
    }

    public class VectorRenderer : IRenderer
    {
        public void RenderCircle(float radius)
        {
            Console.WriteLine($"Drawing a circle of radius {radius}");
        }
    }

    public abstract class Shape
    {
        protected readonly IRenderer Renderer;

        protected Shape(IRenderer renderer)
        {
            Renderer = renderer ?? throw new ArgumentNullException(nameof(renderer));
        }

        public abstract void Draw();
        public abstract void Resize(float factor);
    }

    public class Circle : Shape
    {
        private float _radius;

        public Circle(IRenderer renderer, float radius) : base(renderer)
        {
            _radius = radius;
        }

        public override void Draw()
        {
            Renderer.RenderCircle(_radius);
        }

        public override void Resize(float factor)
        {
            _radius *= factor;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<VectorRenderer>().As<IRenderer>()
                .SingleInstance();
            containerBuilder.Register((c, p) =>
                new Circle(c.Resolve<IRenderer>(),
                    p.Positional<float>(0))
            );

            using var container = containerBuilder.Build();
            var circle = container.Resolve<Circle>(new PositionalParameter(0, 5f));
            circle.Draw();
            circle.Resize(2f);
            circle.Draw();
        }
    }
}