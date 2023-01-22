using System.Collections.Generic;
using ShapesFilter.Algorithms;
using ShapesFilter.Algorithms.LineIntersections;
using ShapesFilter.Algorithms.PointInside;
using ShapesFilter.AlgorithmSelection.Strategies;
using ShapesFilter.Shapes;

namespace ShapesFilter.AlgorithmSelection.Factory
{
    public class RectangleAlgorithmFactory : AlgorithmFactory
    {
        public override bool TryGetStrategy(ShapeType shapeType1, ShapeType shapeType2,
            out IIntersectAlgorithm algorithm)
        {
            if (shapeType1 != ShapeType.Rectangle)
            {
                algorithm = null;
                return false;
            }

            return base.TryGetStrategy(shapeType1, shapeType2, out algorithm);
        }

        public static RectangleAlgorithmFactory GetDefault()
        {
            var factory = new RectangleAlgorithmFactory();
            var strat = new IntersectStrategy(new LineIntersectsRectangle(), new HashSet<ShapeType>
            {
                ShapeType.Line
            });
            factory.AddStrategy(strat);
            strat = new IntersectStrategy(new RectangleIntersectsCircle(), new HashSet<ShapeType>
            {
                ShapeType.Circle
            });
            factory.AddStrategy(strat);
            strat = new IntersectStrategy(new RectangleIntersectsRectangle(new AABBIntersectsAABB()),
                new HashSet<ShapeType>
                {
                    ShapeType.Rectangle
                });
            factory.AddStrategy(strat);
            strat = new IntersectStrategy(
                new PolygonIntersectsPolygon(new AABBIntersectsAABB(), new LineIntersectsLine(),
                    new PointInsidePolygon()), new HashSet<ShapeType>
                {
                    ShapeType.Polygon,
                    ShapeType.Triangle
                });
            factory.AddStrategy(strat);
            return factory;
        }
    }
}