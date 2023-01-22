using System;
using System.Collections.Generic;
using NUnit.Framework;
using ShapesFilter.Algorithms;
using ShapesFilter.Algorithms.LineIntersections;
using ShapesFilter.AlgorithmSelection;
using ShapesFilter.Shapes;

namespace ShapesFilterTests.AlgorithmSelection
{
    [TestFixture]
    public class IntersectStrategyTests
    {
        [Test]
        public void WrongParametersTest()
        {
            Assert.Throws<ArgumentNullException>(() => new IntersectStrategy(null, null));
            Assert.Throws<ArgumentNullException>(() => new IntersectStrategy(new LineIntersectsLine(), null));
            Assert.Throws<ArgumentNullException>(() =>
                new IntersectStrategy(null, new HashSet<ShapeType> { ShapeType.Circle }));
            Assert.Throws<ArgumentException>(() =>
                new IntersectStrategy(new LineIntersectsLine(), new HashSet<ShapeType>()));
        }

        [Test]
        public void CorrectParametersTest()
        {
            var alg = new LineIntersectsLine();
            var strategy = new IntersectStrategy(alg, new HashSet<ShapeType>
            {
                ShapeType.Line
            });
            Assert.That(strategy.Algorithm, Is.EqualTo(alg));
            Assert.That(strategy.AppliedShapes.Count, Is.EqualTo(1));
        }

        [Test]
        public void ValidStrategyTest()
        {
            var alg = new LineIntersectsLine();
            var strategy = new IntersectStrategy(alg, new HashSet<ShapeType>
            {
                ShapeType.Line
            });
            Assert.That(strategy.ValidStrategy(ShapeType.Line), Is.True);
        }

        [Test]
        public void NotValidStrategyTest()
        {
            var alg = new LineIntersectsLine();
            var strategy = new IntersectStrategy(alg, new HashSet<ShapeType>
            {
                ShapeType.Line
            });
            Assert.That(strategy.ValidStrategy(ShapeType.Circle), Is.False);
        }

        [Test]
        public void ChangeAlgorithmTest()
        {
            var strategy = new IntersectStrategy(new LineIntersectsLine(), new HashSet<ShapeType>
            {
                ShapeType.Line
            });
            Assert.Throws<ArgumentNullException>(() => strategy.ChangeAlgorithm(null));
            var alg = new CircleIntersectsCircle();
            strategy.ChangeAlgorithm(alg);
            Assert.That(strategy.Algorithm, Is.EqualTo(alg));
        }
    }
}