using ShapesFilter.Algorithms.PointInside;
using ShapesFilter.Shapes;

namespace ShapesFilter.Algorithms
{
    public class LineIntersectsTriangle : IIntersectValidator<Line, Triangle>
    {
        private readonly LineIntersectsLine _lineIntersectValidator;
        private readonly IPointInside<Triangle> _pointValidator;

        public LineIntersectsTriangle(LineIntersectsLine lineIntersectValidator, IPointInside<Triangle> pointValidator)
        {
            _lineIntersectValidator = lineIntersectValidator;
            _pointValidator = pointValidator;
        }

        public bool Intersect(Line line, Triangle triangle)
        {
            return Intersect(line.P1, line.P2, triangle);
        }

        public bool Intersect(PointF point1, PointF point2, Triangle triangle)
        {
            var vertices = triangle.Vertices;
            for (int i = 0; i < vertices.Length; i++)
            {
                var nextVertex = (i + 1) % 3;
                if (_lineIntersectValidator.Intersect(point1, point2, vertices[i], vertices[nextVertex]))
                {
                    return true;
                }
            }

            return _pointValidator.IsInside(point1, triangle);
        }
    }
}