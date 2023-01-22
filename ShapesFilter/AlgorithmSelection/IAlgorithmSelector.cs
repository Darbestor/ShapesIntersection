using System.Collections.Generic;
using ShapesFilter.Algorithms;
using ShapesFilter.AlgorithmSelection.Factory;
using ShapesFilter.Shapes;

namespace ShapesFilter.AlgorithmSelection
{
    /// <summary>
    ///     Algorithm selection based on shape types
    /// </summary>
    public interface IAlgorithmSelector
    {
        /// <summary>
        ///     List of <see cref="AlgorithmFactory" />
        /// </summary>
        List<AlgorithmFactory> AlgorithmFactories { get; }

        /// <summary>
        ///     Get algorithm
        /// </summary>
        /// <param name="shapeType1">shape type</param>
        /// <param name="shapeType2">shape type</param>
        IIntersectAlgorithm GetAlgorithm(ShapeType shapeType1, ShapeType shapeType2);
    }
}