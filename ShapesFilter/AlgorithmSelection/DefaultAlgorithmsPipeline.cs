using System.Collections.Generic;
using ShapesFilter.Algorithms;
using ShapesFilter.AlgorithmSelection.Factory;
using ShapesFilter.Shapes;

namespace ShapesFilter.AlgorithmSelection
{
    /// <summary>
    ///     Default algorithm selector with predefined algorithms factories
    /// </summary>
    public class DefaultAlgorithmsPipeline : IAlgorithmsPipeline
    {
        public DefaultAlgorithmsPipeline()
        {
            AlgorithmFactories = new List<AlgorithmFactory>
            {
                LineAlgorithmFactory.GetDefault(),
                CircleAlgorithmFactory.GetDefault(),
                PolygonAlgorithmFactory.GetDefault(),
                RectangleAlgorithmFactory.GetDefault(),
                TriangleAlgorithmFactory.GetDefault()
            };
        }

        public List<AlgorithmFactory> AlgorithmFactories { get; }

        public IIntersectAlgorithm GetAlgorithm(ShapeType shapeType1, ShapeType shapeType2)
        {
            foreach (var factory in AlgorithmFactories)
                if (factory.TryGetStrategy(shapeType1, shapeType2, out var algorithm))
                    return algorithm;

            return null;
        }
    }
}