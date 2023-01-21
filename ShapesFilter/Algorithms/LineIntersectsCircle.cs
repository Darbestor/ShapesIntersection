using System;
using ShapesFilter.Shapes;

namespace ShapesFilter.Algorithms
{
    public class LineIntersectsCircle : IIntersectValidator<Line, Circle>
    {
        public bool Intersect(Line line, Circle circle)
        {
            // is either end INSIDE the circle?
            // if so, return true immediately
            var inside1 = PointInCircle(line.P1, circle);
            var inside2 = PointInCircle(line.P2, circle);
            if (inside1 || inside2) return true;

            var v1X = line.P2.X - line.P1.X;
            var v1Y = line.P2.Y - line.P1.Y;
            var v2X = line.P1.X - circle.Center.X;
            var v2Y = line.P1.Y - circle.Center.Y;
            var b = (v1X * v2X + v1Y * v2Y);
            var c = 2 * (v1X * v1X + v1Y * v1Y);
            b *= -2;
            var d = Math.Sqrt(b * b - 2 * c * (v2X * v2X + v2Y * v2Y - circle.Radius * circle.Radius));

            if (!(d > 0)) return false;

            var u1 = (b - d) / c; // these represent the unit distance of point one and two on the line
            var u2 = (b + d) / c;
            return (u1 <= 1 && u1 >= 0) || (u2 <= 1 && u2 >= 0); // if point on the line segment
        }

        private bool PointInCircle(PointF p, Circle c)
        {
            // get distance between the point and circle's center
            // using the Pythagorean Theorem
            float distX = p.X - c.Center.X;
            float distY = p.Y - c.Center.Y;
            float distance = MathF.Sqrt((distX * distX) + (distY * distY));

            // if the distance is less than the circle's 
            // radius the point is inside!
            return distance <= c.Radius;
        }
    }
}