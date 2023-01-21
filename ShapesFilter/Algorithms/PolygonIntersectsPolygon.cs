using System.Collections.Generic;
using System.Linq;
using ShapesFilter.Shapes;

namespace ShapesFilter.Algorithms
{
    public class PolygonIntersectsPolygon : IIntersectValidator<Polygon, Polygon>
    {
        private readonly RectangleIntersectsRectangle _aabbValidator;
        private readonly LineIntersectsLine _lineValidator;

        public PolygonIntersectsPolygon(RectangleIntersectsRectangle aabbValidator, LineIntersectsLine lineValidator)
        {
            _aabbValidator = aabbValidator;
            _lineValidator = lineValidator;
        }

        public bool Intersect(Polygon polygon1, Polygon polygon2)
        {
            if (_aabbValidator.Intersect(polygon1.AABB, polygon2.AABB))
            {
                var p1Vertices = polygon1.Vertices;
                var p2Vertices = polygon2.Vertices;
                
                if (EdgesIntersect(p1Vertices, p2Vertices))
                {
                    return true;
                }
                if (PointInside(p1Vertices, p2Vertices))
                {
                    return true;
                }
            }

            return false;
        }

        private bool EdgesIntersect(IReadOnlyList<PointF> p1Vertices, IReadOnlyList<PointF> p2Vertices)
        {
            for (var i = 0; i < p1Vertices.Count - 1; i++)
            {
                for (var j = 0; j < p2Vertices.Count - 1; j++)
                {
                    if (_lineValidator.Intersect(p1Vertices[i], p1Vertices[i + 1], p2Vertices[j], p2Vertices[j + 1]))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool PointInside(PointF[] p1Vertices, PointF[] p2Vertices)
        {
            return p1Vertices.Any(p => IsInside(p2Vertices, p)) || p2Vertices.Any(p => IsInside(p1Vertices, p));
        }

        private bool IsInside(IReadOnlyList<PointF> polygon, PointF point)
        {
            bool result = false;
            int j = polygon.Count - 1;
            for (int i = 0; i < polygon.Count; i++)
            {
                if (polygon[i].Y < point.Y && polygon[j].Y >= point.Y || polygon[j].Y < point.Y && polygon[i].Y >= point.Y)
                {
                    if (polygon[i].X + (point.Y - polygon[i].Y) / (polygon[j].Y - polygon[i].Y) * (polygon[j].X - polygon[i].X) < point.X)
                    {
                        result = !result;
                    }
                }
                j = i;
            }
            return result;
        }
    }
}