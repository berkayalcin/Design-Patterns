using System;

namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            var point = Point.NewCartesianPoint(1, 3);
            var polarPoint = Point.NewPolarPoint(1.0, Math.PI / 2);
        }
    }
}