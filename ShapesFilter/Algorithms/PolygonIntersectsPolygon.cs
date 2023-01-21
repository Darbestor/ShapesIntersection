using System.Linq;
using ShapesFilter.Algorithms.PointInside;
using ShapesFilter.Shapes;

namespace ShapesFilter.Algorithms
{
    public class PolygonIntersectsPolygon : IIntersectValidator<Polygon, Polygon>
    {
        private readonly RectangleIntersectsRectangle _aabbValidator;
        private readonly LineIntersectsLine _lineValidator;
        private readonly IPointInside<Polygon> _pointValidator;

        public PolygonIntersectsPolygon(RectangleIntersectsRectangle aabbValidator, LineIntersectsLine lineValidator,
            IPointInside<Polygon> pointValidator)
        {
            _aabbValidator = aabbValidator;
            _lineValidator = lineValidator;
            _pointValidator = pointValidator;
        }

        public bool Intersect(Polygon polygon1, Polygon polygon2)
        {
            if (_aabbValidator.Intersect(polygon1.AABB, polygon2.AABB))
            {
                if (EdgesIntersect(polygon1, polygon2))
                {
                    return true;
                }

                return polygon1.Vertices.Any(v => _pointValidator.IsInside(v, polygon2)) ||
                       polygon2.Vertices.Any(v => _pointValidator.IsInside(v, polygon1));
                ;
            }

            return false;
        }

        private bool EdgesIntersect(Polygon p1, Polygon p2)
        {
            var p1Vertices = p1.Vertices;
            var p2Vertices = p2.Vertices;
            for (var i = 0; i < p1Vertices.Length - 1; i++)
            {
                for (var j = 0; j < p2Vertices.Length - 1; j++)
                {
                    if (_lineValidator.Intersect(p1Vertices[i], p1Vertices[i + 1], p2Vertices[j], p2Vertices[j + 1]))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}