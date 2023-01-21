namespace ShapesFilter.Shapes
{
    public class Polygon : IShape
    {
        public Polygon(PointF[] vertices, BoundingBox aabb)
        {
            Vertices = vertices;
            AABB = aabb;
        }

        public PointF[] Vertices { get; }

        /// <summary>
        ///     Axis-aligned bounding box
        /// </summary>
        public BoundingBox AABB { get; }
    }
}