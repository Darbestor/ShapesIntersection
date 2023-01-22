using System;

namespace ShapesFilter.Shapes
{
    /// <summary>
    /// Triangle
    /// </summary>
    public class Triangle : Polygon
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="vertices">points. Points must be equal to 3</param>
        /// <exception cref="ArgumentException">number of point if not 3</exception>
        public Triangle(params PointF[] vertices) : base(vertices)
        {
            if (vertices.Length != 3) throw new ArgumentException("Triangle must have 3 vertices");
            AABB = new BoundingBox(vertices);
            Area = GetArea();
        }

        public override BoundingBox AABB { get; }
        public override float Area { get; }
        public override ShapeType ShapeType => ShapeType.Triangle;

        private float GetArea()
        {
            var p1 = Vertices[0];
            var p2 = Vertices[1];
            var p3 = Vertices[2];
            return 0.5f * MathF.Abs((p2.X - p1.X) * (p3.Y - p1.Y) - (p3.X - p1.X) * (p2.Y - p1.Y));
        }
    }
}