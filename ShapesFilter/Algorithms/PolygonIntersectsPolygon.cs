using System;
using System.Linq;
using ShapesFilter.Algorithms.LineIntersections;
using ShapesFilter.Algorithms.PointInside;
using ShapesFilter.Shapes;

namespace ShapesFilter.Algorithms
{
    public class PolygonIntersectsPolygon : IIntersectValidator
    {
        private readonly RectangleIntersectsRectangle _aabbValidator;
        private readonly LineIntersectsLine _lineValidator;
        private readonly IPointInside<Polygon> _pointValidator;

        public PolygonIntersectsPolygon(RectangleIntersectsRectangle aabbValidator,
            LineIntersectsLine lineValidator,
            IPointInside<Polygon> pointValidator)
        {
            _aabbValidator = aabbValidator;
            _lineValidator = lineValidator;
            _pointValidator = pointValidator;
        }

        public bool Intersect(IShape shape1, IShape shape2)
        {
            if (!(shape1 is Polygon polygon1) || !(shape2 is Polygon polygon2))
            {
                throw new ArgumentException("Wrong shapes");
            }

            if (!_aabbValidator.Intersect(polygon1.AABB, polygon2.AABB)) return false;
            if (EdgesIntersect(polygon1, polygon2)) return true;

            return polygon1.Vertices.Any(v => _pointValidator.IsInside(v, polygon2)) ||
                   polygon2.Vertices.Any(v => _pointValidator.IsInside(v, polygon1));
        }

        private bool EdgesIntersect(Polygon p1, Polygon p2)
        {
            var p1Vertices = p1.Vertices;
            var p2Vertices = p2.Vertices;
            for (var i = 0; i < p1Vertices.Length - 1; i++)
            for (var j = 0; j < p2Vertices.Length - 1; j++)
                if (_lineValidator.Intersect(new Line(p1Vertices[i], p1Vertices[i + 1]),
                        new Line(p2Vertices[j], p2Vertices[j + 1])))
                    return true;

            return false;
        }
    }
}