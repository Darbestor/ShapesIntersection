using System;
using System.Collections.Generic;
using System.Linq;

namespace ShapesFilter.Shapes
{
    public class Triangle : Polygon
    {
        public Triangle(params PointF[] vertices) : base(vertices, new BoundingBox(vertices))
        {
            if (vertices.Length != 3) throw new ArgumentException("Triangle must have 3 vertices");
        }

        public Triangle(IEnumerable<PointF> boundaries) : this(boundaries.ToArray())
        {
        }
    }
}