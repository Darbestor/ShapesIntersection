using System;
using ShapesFilter.Algorithms.PointInside;
using ShapesFilter.Shapes;

namespace ShapesFilter.Algorithms
{
    public class CircleIntersectsPolygon : IIntersectValidator
    {
        private readonly IIntersectValidator _lineCircleValidator;
        private readonly IPointInside<Polygon> _pointValidator;

        public CircleIntersectsPolygon(IIntersectValidator lineCircleValidator,
            IPointInside<Polygon> pointValidator)
        {
            _lineCircleValidator = lineCircleValidator;
            _pointValidator = pointValidator;
        }

        public bool Intersect(IShape shape1, IShape shape2)
        {
            if (!(shape1 is Circle circle) || !(shape2 is Polygon polygon))
            {
                throw new ArgumentException("Wrong shapes");
            }

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