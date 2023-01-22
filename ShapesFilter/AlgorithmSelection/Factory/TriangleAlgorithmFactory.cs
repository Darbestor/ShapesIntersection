using System.Collections.Generic;
using ShapesFilter.Algorithms;
using ShapesFilter.Algorithms.LineIntersections;
using ShapesFilter.Algorithms.PointInside;
using ShapesFilter.AlgorithmSelection.Strategies;
using ShapesFilter.Shapes;

namespace ShapesFilter.AlgorithmSelection.Factory
{
    /// <summary>
    /// Algorithm factory for <see cref="Triangle"/> intersections check
    /// </summary>
    public class TriangleAlgorithmFactory : AlgorithmFactory
    {
        public override bool TryGetStrategy(ShapeType shapeType1, ShapeType shapeType2,
            out IIntersectAlgorithm algorithm)
        {
            if (shapeType1 != ShapeType.Triangle)
            {
                algorithm = null;
                return false;
            }

            return base.TryGetStrategy(shapeType1, shapeType2, out algorithm);
        }

        public static TriangleAlgorithmFactory GetDefault()
        {
            var factory = new TriangleAlgorithmFactory();
            var strat = new IntersectStrategy(
                new LineIntersectsTriangle(new LineIntersectsLine(), new PointInsideTriangle()), new HashSet<ShapeType>
                {
                    ShapeType.Line
                });
            factory.AddStrategy(strat);
            strat = new IntersectStrategy(
                new CircleIntersectsPolygon(new LineIntersectsCircle(new PointInsideCircle()),
                    new PointInsidePolygon()), new HashSet<ShapeType>
                {
                    ShapeType.Circle
                });
            factory.AddStrategy(strat);
            strat = new IntersectStrategy(
                new PolygonIntersectsPolygon(new AABBIntersectsAABB(), new LineIntersectsLine(),
                    new PointInsidePolygon()), new HashSet<ShapeType>
                {
                    ShapeType.Rectangle,
                    ShapeType.Polygon,
                    ShapeType.Triangle
                });
            factory.AddStrategy(strat);
            return factory;
        }
    }
}