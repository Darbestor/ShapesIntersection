using System;
using System.Collections.Generic;
using System.Linq;
using ShapesFilter.Shapes;
using ShapesFilter.Strategy;

namespace ShapesFilter
{
    public class FilteredShape
    {
        public IShape Shape { get; set; }
        public bool Foreground { get; set; } = true;
    }

    /// <summary>
    /// Filter foreground shapes
    /// </summary>
    public class Filter
    {
        /// <summary>
        /// Process all the shapes and mark foreground shapes
        /// </summary>
        /// <param name="shapes"></param>
        /// <param name="threshold">Minimal area for foreground shape </param>
        /// <returns>Shapes with foreground flags</returns>
        /// <exception cref="ArgumentOutOfRangeException">threshold &lt; 0</exception>
        public List<FilteredShape> FilterForegroundShapes(List<IShape> shapes, float threshold)
        {
            if (shapes == null) throw new ArgumentNullException(nameof(shapes));
            if (threshold < 0) throw new ArgumentOutOfRangeException(nameof(threshold));
            if (shapes.Count == 0)
            {
                return new List<FilteredShape>();
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
                    if (strategy.IsIntersect(target.Shape, source.Shape))
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