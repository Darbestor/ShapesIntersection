using System.Collections.Generic;
using System.Linq;

namespace ShapesFilter.Shapes
{
    public class Polygon: IShape
    {
        public PointF[] Vertices { get; }

        public Polygon(params PointF[] vertices)
        {
            Vertices = vertices;
        }

        public Polygon(IEnumerable<PointF> boundaries) : this(boundaries.ToArray())
        {
        }
    }
}