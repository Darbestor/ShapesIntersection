using System.Collections.Generic;
using ShapesFilter.Algorithms;
using ShapesFilter.Algorithms.LineIntersections;
using ShapesFilter.Algorithms.PointInside;
using ShapesFilter.AlgorithmSelection.Strategies;
using ShapesFilter.Shapes;

namespace ShapesFilter.AlgorithmSelection.Factory
{
    public class LineAlgorithmFactory : AlgorithmFactory
    {
        public override bool TryGetStrategy(ShapeType shapeType1, ShapeType shapeType2,
            out IIntersectAlgorithm algorithm)
        {
            if (shapeType1 != ShapeType.Line)
            {
                algorithm = null;
                return false;
            }

            return base.TryGetStrategy(shapeType1, shapeType2, out algorithm);
        }

        public static LineAlgorithmFactory GetDefault()
        {
            var factory = new LineAlgorithmFactory();
            var strat = new IntersectStrategy(new LineIntersectsLine(), new HashSet<ShapeType>
            {
                ShapeType.Line
            });
            factory.AddStrategy(strat);
            strat = new IntersectStrategy(new LineIntersectsCircle(new PointInsideCircle()), new HashSet<ShapeType>
            {
                ShapeType.Circle
            });
            factory.AddStrategy(strat);
            strat = new IntersectStrategy(new LineIntersectsRectangle(), new HashSet<ShapeType>
            {
                ShapeType.Rectangle
            });
            factory.AddStrategy(strat);
            strat = new IntersectStrategy(
                new LineIntersectsTriangle(new LineIntersectsLine(), new PointInsideTriangle()), new HashSet<ShapeType>
                {
                    ShapeType.Triangle
                });
            factory.AddStrategy(strat);
            return factory;
        }
    }
}