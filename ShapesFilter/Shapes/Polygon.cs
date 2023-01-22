namespace ShapesFilter.Shapes
{
    /// <summary>
    ///     Polygon
    /// </summary>
    public abstract class Polygon : IShape
    {
        protected Polygon(PointF[] vertices)
        {
            Vertices = vertices;
        }

        public PointF[] Vertices { get; }

        /// <summary>
        ///     <inheritdoc cref="BoundingBox" />
        /// </summary>
        public abstract BoundingBox AABB { get; }

        public abstract float Area { get; }
        public virtual ShapeType ShapeType => ShapeType.Polygon;
    }
}