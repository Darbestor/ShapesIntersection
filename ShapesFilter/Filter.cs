using System;
using System.Collections.Generic;
using ShapesFilter.AlgorithmSelection;
using ShapesFilter.Shapes;

namespace ShapesFilter
{
    public class FilteredShape
    {
        public IShape Shape { get; set; }
        public bool Foreground { get; set; } = true;
    }

    /// <summary>
    ///     Filter foreground shapes
    /// </summary>
    public class Filter
    {
        private readonly IAlgorithmsPipeline _algorithmsPipeline;

        public Filter(IAlgorithmsPipeline algorithmsPipeline)
        {
            _algorithmsPipeline = algorithmsPipeline;
        }

        /// <summary>
        ///     Process all the shapes and mark foreground shapes
        /// </summary>
        /// <param name="shapes"></param>
        /// <param name="threshold">Minimal area for foreground shape </param>
        /// <returns>Shapes with foreground flags</returns>
        /// <exception cref="ArgumentOutOfRangeException">threshold &lt; 0</exception>
        public List<FilteredShape> FilterForegroundShapes(List<IShape> shapes, float threshold)
        {
            if (shapes == null) throw new ArgumentNullException(nameof(shapes));
            if (threshold < 0) throw new ArgumentOutOfRangeException(nameof(threshold));
            if (shapes.Count == 0) return new List<FilteredShape>();

            var passed = new List<FilteredShape>();
            for (var i = shapes.Count - 1; i >= 0; i--)
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
                    var strategy = _algorithmsPipeline.GetAlgorithm(target.Shape.ShapeType, source.Shape.ShapeType);
                    if (strategy == null)
                        throw new ArgumentNullException(
                            $"Algorithm for {target.Shape.ShapeType} and {source.Shape.ShapeType} not found");

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