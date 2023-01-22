using System.Collections.Generic;
using ShapesFilter.Algorithms;
using ShapesFilter.AlgorithmSelection.Factory;
using ShapesFilter.Shapes;

namespace ShapesFilter.AlgorithmSelection
{
    public interface IAlgorithmSelector
    {
        List<AlgorithmFactory> AlgorithmFactories { get; }
        IIntersectAlgorithm GetAlgorithm(ShapeType shapeType1, ShapeType shapeType2);
    }
}