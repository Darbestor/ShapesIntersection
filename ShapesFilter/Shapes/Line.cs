using System;

namespace ShapesFilter.Shapes
{
    public class Line : IShape
    {
        public PointF P1 { get; }
        public PointF P2 { get; }

        public Line(PointF p1, PointF p2)
        {
            P1 = p1;
            P2 = p2;
        }


        public Line(float x1, float y1, float x2, float y2): this(new PointF(x1, y1), new PointF(x2, y2))
        {
        }

        public override bool Equals(object obj)
        {
            var other = obj as Line;
            if (other == null)
            {
                return false;
            }

            return P1.Equals(other.P1) && P2.Equals(other.P2);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(P1, P2);
        }
    }
}