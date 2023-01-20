namespace ShapesFilter.Shapes
{
    public class Rectangle: IShape
    {
        public PointF TopLeft { get; }
        public PointF BottomRight { get; }

        public Rectangle(PointF topLeft, PointF bottomRight)
        {
            TopLeft = topLeft;
            BottomRight = bottomRight;
        }

        public Rectangle(PointF topLeft, float width, float height) : this(topLeft,
            new PointF(topLeft.X + width, topLeft.Y + height))
        {
        }

        public Rectangle(float top, float left, float width, float height) : this(new PointF(left, top), width, height)
        {
        }
    }
}