using System;
using System.Collections.Generic;
using ShapesFilter.Algorithms;
using ShapesFilter.Shapes;

namespace ShapesFilter.AlgorithmSelection
{
    /// <summary>
    ///     Intersection algorithm for shape type
    /// </summary>
    public class IntersectStrategy
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="algorithm">Algorithm</param>
        /// <param name="shapeTypes">set of types that algorithm applied for</param>
        public IntersectStrategy(IIntersectAlgorithm algorithm, HashSet<ShapeType> shapeTypes)
        {
            Algorithm = algorithm ?? throw new ArgumentNullException(nameof(algorithm));
            AppliedShapes = shapeTypes ?? throw new ArgumentNullException(nameof(shapeTypes));
            if (AppliedShapes.Count == 0) throw new ArgumentException("Applied shape must be at least 1");
        }

        /// <summary>
        ///     <inheritdoc cref="IIntersectAlgorithm" />
        /// </summary>
        public IIntersectAlgorithm Algorithm { get; private set; }

        /// <summary>
        ///     Shapes that algorithm can process
        /// </summary>
        public HashSet<ShapeType> AppliedShapes { get; }

        /// <summary>
        ///     Check if shape type applied for algorithm
        /// </summary>
        /// <param name="shapeType">shape type</param>
        /// <returns>true if algorithm applies for shape type</returns>
        public bool ValidStrategy(ShapeType shapeType)
        {
            return AppliedShapes.Contains(shapeType);
        }

        /// <summary>
        ///     Change algorithm
        /// </summary>
        /// <param name="algorithm">New algorithm</param>
        public void ChangeAlgorithm(IIntersectAlgorithm algorithm)
        {
            Algorithm = algorithm ?? throw new ArgumentNullException(nameof(algorithm));
        }
    }
}