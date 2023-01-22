using System;

namespace ShapesFilter.Shapes
{
    /// <summary>
    /// 2D point
    /// </summary>
    public class PointF : IComparable<PointF>
    {
        public PointF(float x, float y)
        {
            if (x < 0 || !float.IsFinite(x)) throw new ArgumentOutOfRangeException(nameof(x));
            if (y < 0 || !float.IsFinite(y)) throw new ArgumentOutOfRangeException(nameof(y));

            X = x;
            Y = y;
        }

        public float X { get; }
        public float Y { get; }

        public int CompareTo(PointF other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            var xComparison = X.CompareTo(other.X);
            if (xComparison != 0) return xComparison;
            return Y.CompareTo(other.Y);
        }
    }
}