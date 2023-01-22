using System;
using ShapesFilter.Shapes;

namespace ShapesFilter.Algorithms.LineIntersections
{
    /// <summary>
    /// <see cref="Line"/> to <see cref="Line"/> intersection algorithm
    /// </summary>
    public class LineIntersectsLine : IIntersectAlgorithm
    {
        public bool IsIntersect(IShape shape1, IShape shape2)
        {
            if (shape1 == null) throw new ArgumentNullException(nameof(shape1));
            if (shape2 == null) throw new ArgumentNullException(nameof(shape2));

            if (!(shape1 is Line line1) || !(shape2 is Line line2))
            {
                throw new ArgumentException("Wrong shapes");
            }

            return Intersect(line1.P1, line1.P2, line2.P1, line2.P2);
        }

        public bool Intersect(PointF line1P1, PointF line1P2, PointF line2P1, PointF line2P2)
        {
            var denom = (line1P2.X - line1P1.X) * (line2P2.Y - line2P1.Y) -
                        (line1P2.Y - line1P1.Y) * (line2P2.X - line2P1.X);

            // line parallel and do not lie on each other
            if (denom == 0 && !line1P1.Equals(line2P1))
                return false;

            var numer = (line1P1.Y - line2P1.Y) * (line2P2.X - line2P1.X) -
                        (line1P1.X - line2P1.X) * (line2P2.Y - line2P1.Y);

            var r = numer / denom;

            var numer2 = (line1P1.Y - line2P1.Y) * (line1P2.X - line1P1.X) -
                         (line1P1.X - line2P1.X) * (line1P2.Y - line1P1.Y);

            var s = numer2 / denom;

            if (r < 0 || r > 1 || s < 0 || s > 1)
                return false;

            return true;
        }
    }
}