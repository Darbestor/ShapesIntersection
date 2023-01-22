using System;
using System.Linq;
using ShapesFilter.Algorithms.LineIntersections;
using ShapesFilter.Algorithms.PointInside;
using ShapesFilter.Shapes;

namespace ShapesFilter.Algorithms
{
    /// <summary>
    /// <see cref="Polygon"/> to <see cref="Polygon"/> intersection algorithm
    /// </summary>
    public class PolygonIntersectsPolygon : IIntersectAlgorithm
    {
        private readonly AABBIntersectsAABB _aabbValidator;
        private readonly LineIntersectsLine _lineValidator;
        private readonly IPointInside<Polygon> _pointValidator;

        public PolygonIntersectsPolygon(AABBIntersectsAABB aabbValidator,
            LineIntersectsLine lineValidator,
            IPointInside<Polygon> pointValidator)
        {
            _aabbValidator = aabbValidator ?? throw new ArgumentNullException(nameof(aabbValidator));
            _lineValidator = lineValidator ?? throw new ArgumentNullException(nameof(lineValidator));
            _pointValidator = pointValidator ?? throw new ArgumentNullException(nameof(pointValidator));
        }

        public bool IsIntersect(IShape shape1, IShape shape2)
        {
            if (shape1 == null) throw new ArgumentNullException(nameof(shape1));
            if (shape2 == null) throw new ArgumentNullException(nameof(shape2));

            var shapes = new ShapeCaster<Polygon, Polygon>(shape1, shape2);

            if (!_aabbValidator.IsIntersect(shapes.Shape1.AABB, shapes.Shape2.AABB)) return false;
            if (EdgesIntersect(shapes.Shape1, shapes.Shape2)) return true;

            return shapes.Shape1.Vertices.Any(v => _pointValidator.IsInside(v, shapes.Shape2)) ||
                   shapes.Shape2.Vertices.Any(v => _pointValidator.IsInside(v, shapes.Shape1));
        }

        /// <summary>
        /// Check for edges intersection
        /// </summary>
        /// <param name="p1">polygon</param>
        /// <param name="p2">polygon</param>
        /// <returns></returns>
        private bool EdgesIntersect(Polygon p1, Polygon p2)
        {
            var p1Vertices = p1.Vertices;
            var p2Vertices = p2.Vertices;
            for (var i = 0; i < p1Vertices.Length - 1; i++)
            for (var j = 0; j < p2Vertices.Length - 1; j++)
                if (_lineValidator.IsIntersect(new Line(p1Vertices[i], p1Vertices[i + 1]),
                        new Line(p2Vertices[j], p2Vertices[j + 1])))
                    return true;

            return false;
        }
    }
}