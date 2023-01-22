using System;
using ShapesFilter.Algorithms.PointInside;
using ShapesFilter.Shapes;

namespace ShapesFilter.Algorithms.LineIntersections
{
    /// <summary>
    ///     <see cref="Line" /> to <see cref="Triangle" /> intersection algorithm
    /// </summary>
    public class LineIntersectsTriangle : IIntersectAlgorithm
    {
        private readonly LineIntersectsLine _lineIntersectValidator;
        private readonly IPointInside<Triangle> _pointValidator;

        public LineIntersectsTriangle(LineIntersectsLine lineIntersectValidator,
            IPointInside<Triangle> pointValidator)
        {
            _lineIntersectValidator =
                lineIntersectValidator ?? throw new ArgumentNullException(nameof(lineIntersectValidator));
            _pointValidator = pointValidator ?? throw new ArgumentNullException(nameof(pointValidator));
        }

        public bool IsIntersect(IShape shape1, IShape shape2)
        {
            if (shape1 == null) throw new ArgumentNullException(nameof(shape1));
            if (shape2 == null) throw new ArgumentNullException(nameof(shape2));

            var shapes = new ShapeCaster<Line, Triangle>(shape1, shape2);

            var vertices = shapes.Shape2.Vertices;
            for (var i = 0; i < vertices.Length; i++)
            {
                var nextVertex = (i + 1) % 3;
                if (_lineIntersectValidator.IsIntersect(shapes.Shape1, new Line(vertices[i], vertices[nextVertex])))
                    return true;
            }

            return _pointValidator.IsInside(shapes.Shape1.P1, shapes.Shape2);
        }
    }
}