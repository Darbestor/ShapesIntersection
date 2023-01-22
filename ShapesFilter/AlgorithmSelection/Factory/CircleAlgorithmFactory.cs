using System.Collections.Generic;
using ShapesFilter.Algorithms;
using ShapesFilter.Algorithms.LineIntersections;
using ShapesFilter.Algorithms.PointInside;
using ShapesFilter.Shapes;

namespace ShapesFilter.AlgorithmSelection.Factory
{
    /// <summary>
    ///     Algorithm factory for <see cref="Circle" /> intersections check
    /// </summary>
    public class CircleAlgorithmFactory : AlgorithmFactory
    {
        public override bool TryGetStrategy(ShapeType shapeType1, ShapeType shapeType2,
            out IIntersectAlgorithm algorithm)
        {
            if (shapeType1 != ShapeType.Circle)
            {
                algorithm = null;
                return false;
            }

            return base.TryGetStrategy(shapeType1, shapeType2, out algorithm);
        }

        public static CircleAlgorithmFactory GetDefault()
        {
            var factory = new CircleAlgorithmFactory();
            var strat = new IntersectStrategy(new CircleIntersectsCircle(), new HashSet<ShapeType>
            {
                ShapeType.Circle
            });
            factory.AddStrategy(strat);
            strat = new IntersectStrategy(
                new CircleIntersectsPolygon(new LineIntersectsCircle(new PointInsideCircle()),
                    new PointInsidePolygon()), new HashSet<ShapeType>
                {
                    ShapeType.Triangle,
                    ShapeType.Polygon
                });
            factory.AddStrategy(strat);
            strat = new IntersectStrategy(new LineIntersectsCircle(new PointInsideCircle()), new HashSet<ShapeType>
            {
                ShapeType.Line
            });
            factory.AddStrategy(strat);
            strat = new IntersectStrategy(new RectangleIntersectsCircle(), new HashSet<ShapeType>
            {
                ShapeType.Rectangle
            });
            factory.AddStrategy(strat);
            return factory;
        }
    }
}