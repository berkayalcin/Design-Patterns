using System;
using System.Collections.Generic;
using Composite_Specification.Entity;
using Composite_Specification.Specifications;

namespace Composite_Specification
{
    class Program
    {
        static void Main(string[] args)
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
    }
}