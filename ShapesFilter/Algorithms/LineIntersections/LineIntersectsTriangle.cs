using ShapesFilter.Algorithms.PointInside;
using ShapesFilter.Shapes;

namespace ShapesFilter.Algorithms
{
    public class LineIntersectsTriangle : IIntersectValidator<Line, Triangle>
    {
        private readonly IIntersectValidator<Line, Line> _lineIntersectValidator;
        private readonly IPointInside<Triangle> _pointValidator;

        public LineIntersectsTriangle(IIntersectValidator<Line, Line> lineIntersectValidator,
            IPointInside<Triangle> pointValidator)
        {
            _lineIntersectValidator = lineIntersectValidator;
            _pointValidator = pointValidator;
        }

        public bool Intersect(Line line, Triangle triangle)
        {
            var vertices = triangle.Vertices;
            for (var i = 0; i < vertices.Length; i++)
            {
                var nextVertex = (i + 1) % 3;
                if (_lineIntersectValidator.Intersect(line, new Line(vertices[i], vertices[nextVertex])))
                {
                    return true;
                }
            }

            return _pointValidator.IsInside(line.P1, triangle);
        }
    }
}