using System;

namespace ShapesFilter.Shapes
{
    public class Rectangle : Polygon
    {
        public Rectangle(PointF topLeft, PointF bottomRight) : base(
            new[] { topLeft, new PointF(bottomRight.X, topLeft.Y), bottomRight, new PointF(topLeft.X, bottomRight.Y) })
        {
            TopLeft = Vertices[0];
            TopRight = Vertices[1];
            BottomRight = Vertices[2];
            BottomLeft = Vertices[3];
            AABB = new BoundingBox(topLeft, bottomRight);
            Area = Math.Abs(bottomRight.X - topLeft.X) * Math.Abs(topLeft.Y - bottomRight.Y);
        }

        public Rectangle(PointF topLeft, float width, float height) : this(topLeft,
            new PointF(topLeft.X + width, topLeft.Y + height))
        {
        }

        public Rectangle(float top, float left, float width, float height) : this(new PointF(left, top), width, height)
        {
        }

        public PointF TopLeft { get; }
        public PointF BottomRight { get; }
        public PointF BottomLeft { get; }
        public PointF TopRight { get; }
        public override BoundingBox AABB { get; }
        public override float Area { get; }
        public override ShapeType ShapeType => ShapeType.Rectangle;
    }
}