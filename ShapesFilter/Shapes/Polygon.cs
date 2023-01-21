namespace ShapesFilter.Shapes
{
    public abstract class Polygon : IShape
    {
        protected Polygon(PointF[] vertices)
        {
            Vertices = vertices;
        }

        public PointF[] Vertices { get; }

        /// <summary>
        ///     Axis-aligned bounding box
        /// </summary>
        public abstract BoundingBox AABB { get; }

        public abstract float Area { get; }
    }
}