using System;
using Factory;

namespace Inner_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            var point = Point.Factory.NewCartesianPoint(1, 3);
            var origin = Point.Origin;
            Console.WriteLine(point);
        }
    }
}