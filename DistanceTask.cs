using System;

namespace DistanceTask
{
    public static class DistanceTask
    {
        // Расстояние от точки (x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
        public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
        {
            var (a, b) = (by - ay, bx - ax);

            if (a != 0 || b != 0)
            {
                var (x0, y0) = GetPerpendicularPoint(a, b, ax, ay, x, y);

                if (IsInInterval(x0, ax, bx) && IsInInterval(y0, ay, by))
                {
                    double c = ay * b - ax * a;
                    return Math.Abs((a * x - b * y + c) / Math.Sqrt(a * a + b * b));
                }
                else return Math.Min(GetDistance(x, y, ax, ay), GetDistance(x, y, bx, by));
            }
            else return GetDistance(x, y, ax, ay);
        }

        private static (double x0, double y0) GetPerpendicularPoint(double a, double b, double ax, double ay, double x, double y)
        {
            var (c1, c2) = (b * ay - a * ax, x * b + y * a);

            double y0 = (b * c1 + a * c2) / (a * a + b * b);

            double x0;
            if (a == 0)
            {
                x0 = c2 / b;
            }
            else if (b == 0)
            {
                x0 = -c1 / a;
            }
            else
            {
                x0 = b / a * y0 - (c1 / a);
            }

            return (x0, y0);
        }

        static double GetDistance(double x, double y, double zx, double zy)
        {
            return Math.Sqrt((x - zx) * (x - zx) + (y - zy) * (y - zy));
        }

        static bool IsInInterval(double m0, double a0, double b0)
        {
            return m0 <= Math.Max(a0, b0) && m0 >= Math.Min(a0, b0);
        }
    }
}