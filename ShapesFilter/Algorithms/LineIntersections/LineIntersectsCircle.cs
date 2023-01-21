using System;
using ShapesFilter.Algorithms.PointInside;
using ShapesFilter.Shapes;

namespace ShapesFilter.Algorithms.LineIntersections
{
    public class LineIntersectsCircle : IIntersectValidator
    {
        private readonly IPointInside<Circle> _pointValidator;

        public LineIntersectsCircle(IPointInside<Circle> pointValidator)
        {
            _pointValidator = pointValidator;
        }

        public bool Intersect(IShape shape1, IShape shape2)
        {
            if (!(shape1 is Line line) || !(shape2 is Circle circle))
            {
                throw new ArgumentException("Wrong shapes");
            }

            // is either end INSIDE the circle?
            // if so, return true immediately
            var inside1 = _pointValidator.IsInside(line.P1, circle);
            var inside2 = _pointValidator.IsInside(line.P1, circle);
            if (inside1 || inside2) return true;

            var v1X = line.P2.X - line.P1.X;
            var v1Y = line.P2.Y - line.P1.Y;
            var v2X = line.P1.X - circle.Center.X;
            var v2Y = line.P1.Y - circle.Center.Y;
            var b = v1X * v2X + v1Y * v2Y;
            var c = 2 * (v1X * v1X + v1Y * v1Y);
            b *= -2;
            var d = Math.Sqrt(b * b - 2 * c * (v2X * v2X + v2Y * v2Y - circle.Radius * circle.Radius));

            if (!(d > 0)) return false;

            var u1 = (b - d) / c; // these represent the unit distance of point one and two on the line
            var u2 = (b + d) / c;
            return (u1 <= 1 && u1 >= 0) || (u2 <= 1 && u2 >= 0); // if point on the line segment
        }
    }
}