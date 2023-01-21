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
            Area = MathF.PI * MathF.Pow(radius, 2);
        }

        public PointF Center { get; }
        public float Radius { get; }
        public float Area { get; }
        public ShapeType ShapeType => ShapeType.Circle;
    }
}