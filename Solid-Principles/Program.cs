using System;
using System.Diagnostics;

namespace Solid_Principles
{
    class Program
    {
        static void Main(string[] args)
        {
            // SingleResponsiblilty();
            // OpenClosed();
            // LiskovSubstituion();
            // DependencyInversion();
        }

        private static void DependencyInversion()
        {
            var parent = new Person()
            {
                Name = "John"
            };

            var child1 = new Person()
            {
                Name = "Chris"
            };

            var child2 = new Person()
            {
                Name = "Mary"
            };

            var relationships = new Relationships();
            relationships.AddParentAndChild(parent, child1);
            relationships.AddParentAndChild(parent, child2);
        }

        private static void LiskovSubstituion()
        {
            Rectangle rectangle = new Rectangle(2, 3);
            Console.WriteLine($"{rectangle} has area {rectangle.Width * rectangle.Height}");
            Rectangle square = new Square();
            square.Width = 4;
            Console.WriteLine($"{square} has area {square.Width * square.Height}");
        }

        private static void OpenClosed()
        {
            var apple = new Product("Apple", Color.Green, Size.Small);
            var tree = new Product("Tree", Color.Green, Size.Huge);
            var house = new Product("House", Color.Blue, Size.Large);

            Product[] products = {apple, tree, house};
            var betterFilter = new BetterFilter();

            Console.WriteLine("Green Products");

            foreach (var product in betterFilter.Filter(products, new ColorSpecification(Color.Green)))
            {
                Console.WriteLine(product.Name);
            }

            Console.WriteLine("Huge Products");
            foreach (var product in betterFilter.Filter(products, new SizeSpecification(Size.Huge)))
            {
                Console.WriteLine(product.Name);
            }

            Console.WriteLine("Huge and Green Items");

            foreach (var product in betterFilter.Filter(products, new AndSpecification<Product>(
                new ColorSpecification(Color.Green),
                new SizeSpecification(Size.Huge))))
            {
                Console.WriteLine(product.Name);
            }
        }

        private static void SingleResponsiblilty()
        {
            var j = new Journal();

            j.AddEntry("I cried today");
            j.AddEntry("I ate a bug");
            Console.WriteLine(j);

            var persistence = new Persistence();
            var fileName = "journal.txt";
            persistence.SaveToFile(j, fileName, true);
        }
    }
}