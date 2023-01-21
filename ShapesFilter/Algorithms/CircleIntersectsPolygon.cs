using ShapesFilter.Algorithms.PointInside;
using ShapesFilter.Shapes;

namespace ShapesFilter.Algorithms
{
    public class CircleIntersectsPolygon : IIntersectValidator<Circle, Polygon>
    {
        private readonly IIntersectValidator<Line, Circle> _lineCircleValidator;
        private readonly IPointInside<Polygon> _pointValidator;

        public CircleIntersectsPolygon(IIntersectValidator<Line, Circle> lineCircleValidator,
            IPointInside<Polygon> pointValidator)
        {
            _lineCircleValidator = lineCircleValidator;
            _pointValidator = pointValidator;
        }

        public bool Intersect(Circle circle, Polygon polygon)
        {
            var vertices = polygon.Vertices;
            for (var i = 0; i < vertices.Length; i++)
            {
                var nextVertex = (i + 1) % 3;
                if (_lineCircleValidator.Intersect(new Line(vertices[i], vertices[nextVertex]), circle)) return true;
            }

            return _pointValidator.IsInside(circle.Center, polygon);
        }
    }
}