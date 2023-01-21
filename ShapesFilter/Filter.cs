using System.Collections.Generic;
using System.Linq;
using ShapesFilter.DI;
using ShapesFilter.Shapes;

namespace ShapesFilter
{
    public class FilteredShape
    {
        public IShape Shape { get; set; }
        public bool Foreground { get; set; } = true;
    }

    public class Filter
    {
        // Проверять только элементы которые в данный момент на переднем плане
        public List<FilteredShape> FilterForegroundShapes(List<IShape> shapes, float threshold)
        {
            if (shapes == null || shapes.Count == 0)
            {
                return null;
            }

            var passed = new List<FilteredShape>
            {
                new FilteredShape { Shape = shapes.Last(), Foreground = true },
            };
            for (var i = shapes.Count - 2; i >= 0; i--)
            {
                var target = new FilteredShape { Shape = shapes[i] };
                if (target.Shape.Area < threshold)
                {
                    target.Foreground = false;
                    passed.Add(target);
                    continue;
                }

                foreach (var source in passed)
                {
                    var strategy = StrategySelector.GetStrategy(target.Shape.ShapeType, source.Shape.ShapeType);
                    if (strategy.Intersect(target.Shape, source.Shape))
                    {
                        target.Foreground = false;
                        break;
                    }
                }

                passed.Add(target);
            }

            passed.Reverse();
            return passed;
        }
    }
}