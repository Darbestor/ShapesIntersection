using System.Collections.Generic;
using NUnit.Framework;
using ShapesFilter.Algorithms.LineIntersections;
using ShapesFilter.AlgorithmSelection;
using ShapesFilter.AlgorithmSelection.Factory;
using ShapesFilter.Shapes;

namespace ShapesFilterTests.AlgorithmSelection.Factory
{
    [TestFixture]
    public class LineAlgorithmFactoryTests
    {
        [SetUp]
        public void Setup()
        {
            _factory = new LineAlgorithmFactory();
        }

        private LineAlgorithmFactory _factory;

        [Test]
        [TestCase(ShapeType.Rectangle)]
        [TestCase(ShapeType.Circle)]
        [TestCase(ShapeType.Triangle)]
        [TestCase(ShapeType.Polygon)]
        public void WrongShapeTypeTest(ShapeType type)
        {
            Assert.That(_factory.TryGetStrategy(type, type, out var res), Is.False);
            Assert.That(res, Is.Null);
        }

        [Test]
        public void CorrectShapeWithAlgorithmTest()
        {
            var strategy = new IntersectStrategy(new LineIntersectsLine(), new HashSet<ShapeType>
            {
                ShapeType.Line
            });
            _factory.AddStrategy(strategy);
            Assert.That(_factory.TryGetStrategy(ShapeType.Line, ShapeType.Line, out var res), Is.True);
            Assert.That(res, Is.EqualTo(strategy.Algorithm));
        }

        [Test]
        public void CorrectShapeNoAlgorithmsTest()
        {
            Assert.That(_factory.TryGetStrategy(ShapeType.Line, ShapeType.Circle, out var res), Is.False);
            Assert.That(res, Is.Null);
        }
    }
}