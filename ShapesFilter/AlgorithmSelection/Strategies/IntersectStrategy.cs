using System.Collections.Generic;
using ShapesFilter.Algorithms;
using ShapesFilter.Shapes;

namespace ShapesFilter.AlgorithmSelection.Strategies
{
    public class IntersectStrategy
    {
        public IntersectStrategy(IIntersectAlgorithm algorithm, HashSet<ShapeType> shapeTypes)
        {
            Algorithm = algorithm;
            AppliedShapes = shapeTypes;
        }

        public IIntersectAlgorithm Algorithm { get; set; }

        public HashSet<ShapeType> AppliedShapes { get; }

        public bool ValidStrategy(ShapeType shapeType)
        {
            return AppliedShapes.Contains(shapeType);
        }
    }
}