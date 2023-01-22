using System;
using ShapesFilter.Algorithms.LineIntersections;
using ShapesFilter.Algorithms.PointInside;
using ShapesFilter.Shapes;

namespace ShapesFilter.Algorithms
{
    /// <summary>
    /// <see cref="Circle"/> to <see cref="Polygon"/> intersection algorithm
    /// </summary>
    public class CircleIntersectsPolygon : IIntersectAlgorithm
    {
        private readonly LineIntersectsCircle _lineCircleValidator;
        private readonly IPointInside<Polygon> _pointValidator;

        public CircleIntersectsPolygon(LineIntersectsCircle lineCircleValidator,
            IPointInside<Polygon> pointValidator)
        {
            _lineCircleValidator = lineCircleValidator ?? throw new ArgumentNullException(nameof(lineCircleValidator));
            _pointValidator = pointValidator ?? throw new ArgumentNullException(nameof(pointValidator));
        }

        public bool IsIntersect(IShape shape1, IShape shape2)
        {
            if (shape1 == null) throw new ArgumentNullException(nameof(shape1));
            if (shape2 == null) throw new ArgumentNullException(nameof(shape2));

            var shapes = new ShapeCaster<Circle, Polygon>(shape1, shape2);

            var vertices = shapes.Shape2.Vertices;
            for (var i = 0; i < vertices.Length; i++)
            {
                var nextVertex = (i + 1) % 3;
                if (_lineCircleValidator.IsIntersect(new Line(vertices[i], vertices[nextVertex]), shapes.Shape1))
                    return true;
            }

            return _pointValidator.IsInside(shapes.Shape1.Center, shapes.Shape2);
        }
    }
}