﻿using System.Collections.Generic;
using ShapesFilter.Algorithms;
using ShapesFilter.AlgorithmSelection.Factory;
using ShapesFilter.Shapes;

namespace ShapesFilter.AlgorithmSelection
{
    public class DefaultAlgorithmSelector : IAlgorithmSelector
    {
        public DefaultAlgorithmSelector()
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
            {
                if (factory.TryGetStrategy(shapeType1, shapeType2, out var algorithm))
                {
                    return algorithm;
                }
            }

            return null;
        }
    }
}