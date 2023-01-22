using System.Collections.Generic;
using ShapesFilter.Algorithms;
using ShapesFilter.Algorithms.LineIntersections;
using ShapesFilter.Algorithms.PointInside;
using ShapesFilter.Shapes;

namespace ShapesFilter.AlgorithmSelection.Factory
{
    /// <summary>
    ///     Algorithm factory for <see cref="Polygon" /> intersections check
    /// </summary>
    public class PolygonAlgorithmFactory : AlgorithmFactory
    {
        public override bool TryGetStrategy(ShapeType shapeType1, ShapeType shapeType2,
            out IIntersectAlgorithm algorithm)
        {
            if (shapeType1 != ShapeType.Polygon)
            {
                algorithm = null;
                return false;
            }

            return base.TryGetStrategy(shapeType1, shapeType2, out algorithm);
        }

        public static PolygonAlgorithmFactory GetDefault()
        {
            var factory = new PolygonAlgorithmFactory();
            var strat = new IntersectStrategy(
                new PolygonIntersectsPolygon(new AABBIntersectsAABB(), new LineIntersectsLine(),
                    new PointInsidePolygon()), new HashSet<ShapeType>
                {
                    ShapeType.Polygon,
                    ShapeType.Triangle,
                    ShapeType.Rectangle
                });
            factory.AddStrategy(strat);
            strat = new IntersectStrategy(
                new CircleIntersectsPolygon(new LineIntersectsCircle(new PointInsideCircle()),
                    new PointInsidePolygon()), new HashSet<ShapeType>
                {
                    ShapeType.Circle
                });
            factory.AddStrategy(strat);
            return factory;
        }
    }
}