using System;

namespace Factory
{
    public class Point
    {
        private double _x, _y;

        private Point(double x, double y)
        {
            _x = x;
            _y = y;
        }

        public override string ToString()
        {
            return $"{nameof(_x)}: {_x}, {nameof(_y)}: {_y}";
        }


        public static readonly Point Origin = new Point(0, 0);

        public static class Factory
        {
            /// <summary>
            /// Factory-Method Method
            /// </summary>
            /// <param name="x">X Coordinate</param>
            /// <param name="y">Y Coordinate</param>
            /// <returns></returns>
            public static Point NewCartesianPoint(double x, double y)
            {
                return new Point(x, y);
            }

            public static Point NewPolarPoint(double rho, double theta)
            {
                return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
            }
        }
    }
}