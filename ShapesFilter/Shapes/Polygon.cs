using System.Collections.Generic;
using System.Linq;

namespace ShapesFilter.Shapes
{
    public class Polygon: IShape
    {
        public PointF[] Vertices { get; }
        
        /// <summary>
        /// Axis-aligned bounding box
        /// </summary>
        public BoundingBox AABB { get; }

        public Polygon(PointF[] vertices, BoundingBox aabb)
        {
            Vertices = vertices;
            AABB = aabb;
        }
    }
}