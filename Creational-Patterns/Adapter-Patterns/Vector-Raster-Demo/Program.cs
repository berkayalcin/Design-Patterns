using System;
using System.Collections.Generic;
using MoreLinq.Extensions;

namespace Vector_Raster_Demo
{
    class Program
    {
        private static readonly List<VectorObject> _vectorObjects = new List<VectorObject>()
        {
            new VectorRectangle(1, 1, 10, 10),
            new VectorRectangle(3, 3, 6, 6)
        };

        public static void DrawPoint(Point p)
        {
            Console.Write(".");
        }

        private static void Draw()
        {
            foreach (var vo in _vectorObjects)
            {
                foreach (var line in vo)
                {
                    var adapter = new LineToPointAdapter(line);
                    adapter.ForEach(DrawPoint);
                }
            }
        }

        static void Main(string[] args)
        {
            Draw();
            Draw();
        }
    }
}