using System;
using ShapesFilter.Shapes;

namespace ShapesFilter.Algorithms.PointInside
{
    /// <summary>
    /// Check if <see cref="PointF"/> is inside<see cref="Triangle"/>
    /// </summary>
    public class PointInsideTriangle : IPointInside<Triangle>
    {
        public bool IsInside(PointF target, Triangle shape)
        {
            if (target == null) throw new ArgumentNullException(nameof(target));
            if (shape == null) throw new ArgumentNullException(nameof(shape));

            var v1 = shape.Vertices[0];
            var v2 = shape.Vertices[1];
            var v3 = shape.Vertices[2];
            var s = (v1.X - v3.X) * (target.Y - v3.Y) - (v1.Y - v3.Y) * (target.X - v3.X);
            var t = (v2.X - v1.X) * (target.Y - v1.Y) - (v2.Y - v1.Y) * (target.X - v1.X);

            if (s < 0 != t < 0 && s != 0 && t != 0)
                return false;

            var d = (v3.X - v2.X) * (target.Y - v2.Y) - (v3.Y - v2.Y) * (target.X - v2.X);
            return d == 0 || d < 0 == s + t <= 0;
        }
    }
}