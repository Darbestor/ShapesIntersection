using System.Collections.Generic;
using ShapesFilter.Algorithms;
using ShapesFilter.Algorithms.LineIntersections;
using ShapesFilter.Shapes;

namespace ShapesFilter.DI
{
    public static class StrategySelector
    {
        private static readonly Dictionary<(ShapeType, ShapeType), IIntersectValidator> _validators;

        static StrategySelector()
        {
            _validators = new Dictionary<(ShapeType, ShapeType), IIntersectValidator>
            {
                { (ShapeType.Line, ShapeType.Line), new LineIntersectsLine() }
            };
        }


        public static IIntersectValidator GetStrategy(ShapeType shape1, ShapeType shape2)
        {
            return _validators.TryGetValue((shape1, shape2), out var v) ? v : null;
        }
    }
}