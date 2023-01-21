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
            var shapes = new ShapeCaster<Line, Triangle>(shape1, shape2);

            var vertices = shapes.Shape2.Vertices;
            for (var i = 0; i < vertices.Length; i++)
            {
                var nextVertex = (i + 1) % 3;
                if (_lineIntersectValidator.Intersect(shapes.Shape1, new Line(vertices[i], vertices[nextVertex])))
                    return true;
            }

            return _pointValidator.IsInside(shapes.Shape1.P1, shapes.Shape2);
        }
    }
}