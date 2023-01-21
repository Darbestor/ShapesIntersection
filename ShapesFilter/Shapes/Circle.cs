using System;

namespace ShapesFilter.Shapes
{
    public class Circle : IShape
    {
        public Circle(PointF center, float radius)
        {
            if (radius < 0) throw new ArgumentException("Radius must be > 0");

            Center = center;
            Radius = radius;
        }

        public PointF Center { get; }
        public float Radius { get; }
    }
}