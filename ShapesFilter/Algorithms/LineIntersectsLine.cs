using ShapesFilter.Algorithm;
using ShapesFilter.Shapes;

namespace ShapesFilter.Algorithms
{
    public class LineIntersectsLine: IIntersectValidator<Line, Line>
    {
        public bool Intersect(Line line1, Line line2)
        {
            return Intersect(line1.P1, line1.P2, line2.P1, line2.P2);
        }

        public bool Intersect(PointF line1P1, PointF line1P2, PointF line2P1, PointF line2P2)
        {
            float denom = ((line1P2.X - line1P1.X) * (line2P2.Y - line2P1.Y)) -
                          ((line1P2.Y - line1P1.Y) * (line2P2.X - line2P1.X));

            // line parallel and do not lie on each other
            if (denom == 0 && !line1P1.Equals(line2P1))
                return false;

            float numer = ((line1P1.Y - line2P1.Y) * (line2P2.X - line2P1.X)) -
                          ((line1P1.X - line2P1.X) * (line2P2.Y - line2P1.Y));

            float r = numer / denom;

            float numer2 = ((line1P1.Y - line2P1.Y) * (line1P2.X - line1P1.X)) -
                           ((line1P1.X - line2P1.X) * (line1P2.Y - line1P1.Y));

            float s = numer2 / denom;

            if ((r < 0 || r > 1) || (s < 0 || s > 1))
                return false;

            return true;
        }
    }
}