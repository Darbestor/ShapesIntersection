using System.Collections.Generic;
using NUnit.Framework;
using ShapesFilter.Algorithms.LineIntersections;
using ShapesFilter.Algorithms.PointInside;
using ShapesFilter.AlgorithmSelection.Factory;
using ShapesFilter.AlgorithmSelection.Strategies;
using ShapesFilter.Shapes;

namespace ShapesFilterTests.AlgorithmSelection.Factory
{
    [TestFixture]
    public class TriangleAlgorithmFactoryTests
    {
        [SetUp]
        public void Setup()
        {
            _factory = new TriangleAlgorithmFactory();
        }

        private TriangleAlgorithmFactory _factory;

        [Test]
        [TestCase(ShapeType.Line)]
        [TestCase(ShapeType.Circle)]
        [TestCase(ShapeType.Rectangle)]
        [TestCase(ShapeType.Polygon)]
        public void WrongShapeTypeTest(ShapeType type)
        {
            Assert.That(_factory.TryGetStrategy(type, type, out var res), Is.False);
            Assert.That(res, Is.Null);
        }

        [Test]
        public void CorrectShapeWithAlgorithmTest()
        {
            var strategy = new IntersectStrategy(
                new LineIntersectsTriangle(new LineIntersectsLine(), new PointInsideTriangle()), new HashSet<ShapeType>
                {
                    ShapeType.Line
                });
            _factory.AddStrategy(strategy);
            Assert.That(_factory.TryGetStrategy(ShapeType.Triangle, ShapeType.Line, out var res), Is.True);
            Assert.That(res, Is.EqualTo(strategy.Algorithm));
        }

        [Test]
        public void CorrectShapeNoAlgorithmsTest()
        {
            Assert.That(_factory.TryGetStrategy(ShapeType.Triangle, ShapeType.Line, out var res), Is.False);
            Assert.That(res, Is.Null);
        }
    }
}