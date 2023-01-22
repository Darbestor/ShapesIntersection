using System.Collections.Generic;
using NUnit.Framework;
using ShapesFilter.Algorithms;
using ShapesFilter.AlgorithmSelection;
using ShapesFilter.AlgorithmSelection.Factory;
using ShapesFilter.Shapes;

namespace ShapesFilterTests.AlgorithmSelection.Factory
{
    [TestFixture]
    public class CircleAlgorithmFactoryTests
    {
        [SetUp]
        public void Setup()
        {
            _factory = new CircleAlgorithmFactory();
        }

        private CircleAlgorithmFactory _factory;

        [Test]
        [TestCase(ShapeType.Rectangle)]
        [TestCase(ShapeType.Line)]
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
            var strategy = new IntersectStrategy(new CircleIntersectsCircle(), new HashSet<ShapeType>
            {
                ShapeType.Circle
            });
            _factory.AddStrategy(strategy);
            Assert.That(_factory.TryGetStrategy(ShapeType.Circle, ShapeType.Circle, out var res), Is.True);
            Assert.That(res, Is.EqualTo(strategy.Algorithm));
        }

        [Test]
        public void CorrectShapeNoAlgorithmsTest()
        {
            Assert.That(_factory.TryGetStrategy(ShapeType.Circle, ShapeType.Circle, out var res), Is.False);
            Assert.That(res, Is.Null);
        }
    }
}