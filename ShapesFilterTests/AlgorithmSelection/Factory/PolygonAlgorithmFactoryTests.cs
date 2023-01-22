using System.Collections.Generic;
using NUnit.Framework;
using ShapesFilter.Algorithms;
using ShapesFilter.Algorithms.LineIntersections;
using ShapesFilter.Algorithms.PointInside;
using ShapesFilter.AlgorithmSelection.Factory;
using ShapesFilter.AlgorithmSelection.Strategies;
using ShapesFilter.Shapes;

namespace ShapesFilterTests.AlgorithmSelection.Factory
{
    [TestFixture]
    public class PolygonAlgorithmFactoryTests
    {
        [SetUp]
        public void Setup()
        {
            _factory = new PolygonAlgorithmFactory();
        }

        private PolygonAlgorithmFactory _factory;

        [Test]
        [TestCase(ShapeType.Rectangle)]
        [TestCase(ShapeType.Circle)]
        [TestCase(ShapeType.Triangle)]
        [TestCase(ShapeType.Line)]
        public void WrongShapeTypeTest(ShapeType type)
        {
            Assert.That(_factory.TryGetStrategy(type, type, out var res), Is.False);
            Assert.That(res, Is.Null);
        }

        [Test]
        public void CorrectShapeWithAlgorithmTest()
        {
            var strategy = new IntersectStrategy(
                new CircleIntersectsPolygon(new LineIntersectsCircle(new PointInsideCircle()),
                    new PointInsidePolygon()), new HashSet<ShapeType>
                {
                    ShapeType.Circle
                });
            _factory.AddStrategy(strategy);
            Assert.That(_factory.TryGetStrategy(ShapeType.Polygon, ShapeType.Circle, out var res), Is.True);
            Assert.That(res, Is.EqualTo(strategy.Algorithm));
        }

        [Test]
        public void CorrectShapeNoAlgorithmsTest()
        {
            Assert.That(_factory.TryGetStrategy(ShapeType.Polygon, ShapeType.Polygon, out var res), Is.False);
            Assert.That(res, Is.Null);
        }
    }
}