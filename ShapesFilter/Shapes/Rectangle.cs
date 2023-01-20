namespace ShapesFilter.Shapes
{
    public class Rectangle: IShape
    {
        public PointF Min { get; }
        public PointF Max { get; }

        public Rectangle(PointF topLeft, PointF bottomRight)
        {
            Min = topLeft;
            Max = bottomRight;
        }

        public Rectangle(PointF topLeft, float width, float height) : this(topLeft,
            new PointF(topLeft.X + width, topLeft.Y + height))
        {
        }

        public Rectangle(float top, float left, float width, float height) : this(new PointF(top, left), width, height)
        {
        }
    }
}