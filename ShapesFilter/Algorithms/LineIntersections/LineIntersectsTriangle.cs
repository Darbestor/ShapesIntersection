using System;
using ShapesFilter.Algorithms.PointInside;
using ShapesFilter.Shapes;

namespace ShapesFilter.Algorithms.LineIntersections
{
    public class LineIntersectsTriangle : IIntersectValidator
    {
        private readonly LineIntersectsLine _lineIntersectValidator;
        private readonly IPointInside<Triangle> _pointValidator;

        public LineIntersectsTriangle(LineIntersectsLine lineIntersectValidator,
            IPointInside<Triangle> pointValidator)
        {
            _lineIntersectValidator = lineIntersectValidator;
            _pointValidator = pointValidator;
        }

        public bool Intersect(IShape shape1, IShape shape2)
        {
            if (!(shape1 is Line line) || !(shape2 is Triangle triangle))
            {
                throw new ArgumentException("Wrong shapes");
            }

            var vertices = triangle.Vertices;
            for (var i = 0; i < vertices.Length; i++)
            {
                var nextVertex = (i + 1) % 3;
                if (_lineIntersectValidator.Intersect(line, new Line(vertices[i], vertices[nextVertex]))) return true;
            }

            return _pointValidator.IsInside(line.P1, triangle);
        }
    }
}