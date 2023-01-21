using System.Collections.Generic;
using System.Linq;
using ShapesFilter.DI;
using ShapesFilter.Shapes;

namespace ShapesFilter
{
    public class FilteredShape
    {
        public IShape Shape { get; set; }
        public bool Foreground { get; set; }
    }

    public class Filter
    {
        // Проверять только элементы которые в данный момент на переднем плане
        public List<FilteredShape> FilterForegroundShapes(List<IShape> shapes)
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
                for (var j = i + 1; j < shapes.Count - 1; j++)
                {
                    var source = shapes[j];
                    var strategy = StrategySelector.GetStrategy(target.Shape.ShapeType, source.ShapeType);
                    if (strategy.Intersect(target.Shape, source))
                    {
                        target.Foreground = true;
                        break;
                    }
                }
            }

            return passed;
        }
    }
}