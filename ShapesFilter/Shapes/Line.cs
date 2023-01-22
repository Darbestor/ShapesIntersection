namespace ShapesFilter.Shapes
{
    /// <summary>
    /// Line
    /// </summary>
    public class Line : IShape
    {
        public Line(PointF p1, PointF p2)
        {
            P1 = p1;
            P2 = p2;
            Area = 0;
        }


        public Line(float x1, float y1, float x2, float y2) : this(new PointF(x1, y1), new PointF(x2, y2))
        {
        }

        public PointF P1 { get; }
        public PointF P2 { get; }

        public float Area { get; }
        public ShapeType ShapeType => ShapeType.Line;
    }
}