using System.Collections.Generic;
using ShapesFilter.Algorithms;
using ShapesFilter.Algorithms.LineIntersections;
using ShapesFilter.Shapes;

namespace ShapesFilter.DI
{
    class StrategySelector<S1, S2>
        where S1 : IShape
        where S2 : IShape
    {
        private readonly Dictionary<(ShapeType, ShapeType), IIntersectValidator<S1, S2>> _validators;

        public StrategySelector()
        {
            _validators = new Dictionary<(ShapeType, ShapeType), IIntersectValidator<S1, S2>>
            {
                { (ShapeType.Line, ShapeType.Line), (IIntersectValidator<S1, S2>)new LineIntersectsLine() }
            };
        }


        public IIntersectValidator<S1, S2> GetStrategy(S1 shape1, S2 shape2)
        {
            return _validators.TryGetValue((shape1.ShapeType, shape2.ShapeType), out var v) ? v : null;
        }
    }
}