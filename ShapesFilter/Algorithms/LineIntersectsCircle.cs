using System;
using ShapesFilter.Shapes;

namespace ShapesFilter.Algorithms
{
    public class LineIntersectsCircle : IIntersectValidator<Line, Circle>
    {
        public bool Intersect(Line line, Circle circle)
        {
            double y;
            double B, C, D;
            var (m, c) = (line.Slope, line.YIntercept);
            var (p, q, r) = (circle.Center.X, circle.Center.Y, circle.Radius);

            if (line.IsVertical)
            {
                double x = line.P1.X;
                B = -2 * q;
                C = p * p + q * q - r * r + x * x - 2 * p * x;
                D = B * B - 4 * C;
                if (D == 0)
                {
                    if (GetDistance(line.P1, circle.Center) < r || GetDistance(line.P2, circle.Center) < r)
                    {
                        return true;
                    }

                    return false;
                }

                if (D > 0)
                {
                    return true;
                }
            }
            else
            {
                var A = m * m + 1;
                B = 2 * (m * c - m * q - p);
                C = p * p + q * q - r * r + c * c - 2 * c * q;
                D = B * B - 4 * A * C;
                if (D == 0)
                {
                    if (GetDistance(line.P1, circle.Center) < r || GetDistance(line.P2, circle.Center) < r)
                    {
                        return true;
                    }

                    return false;
                }

                if (D > 0)
                {
                    return true;
                }
            }

            return false;
        }

        private double GetDistance(PointF p1, PointF p2)
        {
            return Math.Pow((p1.X - p2.X), 2) + Math.Pow((p1.Y - p2.Y), 2);
        }
    }
}