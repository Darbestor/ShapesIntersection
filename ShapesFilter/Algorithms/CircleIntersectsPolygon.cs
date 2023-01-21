using ShapesFilter.Algorithms.LineIntersections;
using ShapesFilter.Algorithms.PointInside;
using ShapesFilter.Shapes;

namespace ShapesFilter.Algorithms
{
    public class CircleIntersectsPolygon : IIntersectValidator
    {
        private readonly LineIntersectsCircle _lineCircleValidator;
        private readonly IPointInside<Polygon> _pointValidator;

        public CircleIntersectsPolygon(LineIntersectsCircle lineCircleValidator,
            IPointInside<Polygon> pointValidator)
        {
            _lineCircleValidator = lineCircleValidator;
            _pointValidator = pointValidator;
        }

        public bool Intersect(IShape shape1, IShape shape2)
        {
            var shapes = new ShapeCaster<Circle, Polygon>(shape1, shape2);

            var vertices = shapes.Shape2.Vertices;
            for (var i = 0; i < vertices.Length; i++)
            {
                var nextVertex = (i + 1) % 3;
                if (_lineCircleValidator.Intersect(new Line(vertices[i], vertices[nextVertex]), shapes.Shape1))
                    return true;
            }

            return _pointValidator.IsInside(shapes.Shape1.Center, shapes.Shape2);
        }
    }
}