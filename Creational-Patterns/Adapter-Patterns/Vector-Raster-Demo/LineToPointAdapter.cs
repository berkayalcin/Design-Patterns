using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Vector_Raster_Demo
{
    public class LineToPointAdapter : IEnumerable<Point>
    {
        private static int _count;

        private static Dictionary<int, List<Point>> _cache
            = new Dictionary<int, List<Point>>();

        public LineToPointAdapter(Line line)
        {
            var hashCode = line.GetHashCode();
            if (_cache.ContainsKey(hashCode))
                return;


            Console.WriteLine($"{++_count}: Generating Points for line : [{line.Start.X},{line.Start.Y}]-" +
                              $"[{line.End.X},{line.End.Y}]");

            var points = new List<Point>();

            int left = Math.Min(line.Start.X, line.End.X);
            int right = Math.Max(line.Start.X, line.End.X);
            int top = Math.Min(line.Start.Y, line.End.Y);
            int bottom = Math.Max(line.Start.Y, line.End.Y);
            int dx = right - left;
            int dy = line.End.Y - line.Start.Y;

            if (dx == 0)
                for (var y = top; y <= bottom; ++y)
                {
                    points.Add(new Point(left, y));
                }
            else if (dy == 0)
                for (var x = left; x <= right; ++x)
                {
                    points.Add(new Point(x, top));
                }

            _cache.Add(hashCode, points);
        }

        public IEnumerator<Point> GetEnumerator()
        {
            return _cache.Values.SelectMany(x => x).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}