using System;
using ShapesFilter.Algorithms.PointInside;
using ShapesFilter.Shapes;

namespace ShapesFilter.Algorithms.LineIntersections
{
    /// <summary>
    ///     <see cref="Line" /> to <see cref="Circle" /> intersection algorithm
    /// </summary>
    public class LineIntersectsCircle : IIntersectAlgorithm
    {
        private readonly IPointInside<Circle> _pointValidator;

        public LineIntersectsCircle(IPointInside<Circle> pointValidator)
        {
            _pointValidator = pointValidator ?? throw new ArgumentNullException(nameof(pointValidator));
        }

        public bool IsIntersect(IShape shape1, IShape shape2)
        {
            if (shape1 == null) throw new ArgumentNullException(nameof(shape1));
            if (shape2 == null) throw new ArgumentNullException(nameof(shape2));

            var shapes = new ShapeCaster<Line, Circle>(shape1, shape2);

            // is either end INSIDE the circle?
            // if so, return true immediately
            var inside1 = _pointValidator.IsInside(shapes.Shape1.P1, shapes.Shape2);
            var inside2 = _pointValidator.IsInside(shapes.Shape1.P1, shapes.Shape2);
            if (inside1 || inside2) return true;

            var v1X = shapes.Shape1.P2.X - shapes.Shape1.P1.X;
            var v1Y = shapes.Shape1.P2.Y - shapes.Shape1.P1.Y;
            var v2X = shapes.Shape1.P1.X - shapes.Shape2.Center.X;
            var v2Y = shapes.Shape1.P1.Y - shapes.Shape2.Center.Y;
            var b = v1X * v2X + v1Y * v2Y;
            var c = 2 * (v1X * v1X + v1Y * v1Y);
            b *= -2;
            var d = Math.Sqrt(b * b - 2 * c * (v2X * v2X + v2Y * v2Y - shapes.Shape2.Radius * shapes.Shape2.Radius));

            if (!(d > 0)) return false;

            var u1 = (b - d) / c; // these represent the unit distance of point one and two on the line
            var u2 = (b + d) / c;
            return (u1 <= 1 && u1 >= 0) || (u2 <= 1 && u2 >= 0); // if point on the line segment
        }
    }
}