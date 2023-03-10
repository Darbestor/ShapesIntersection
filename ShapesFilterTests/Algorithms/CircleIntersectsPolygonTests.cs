using System.Collections.Generic;
using NUnit.Framework;
using ShapesFilter.Algorithms;
using ShapesFilter.Algorithms.LineIntersections;
using ShapesFilter.Algorithms.PointInside;
using ShapesFilter.Shapes;

namespace ShapesFilterTests.Algorithms
{
    [TestFixture]
    public class CircleIntersectsPolygonTests
    {
        [SetUp]
        public void Setup()
        {
            _algorithm = new CircleIntersectsPolygon(new LineIntersectsCircle(new PointInsideCircle()),
                new PointInsidePolygon());
        }

        private CircleIntersectsPolygon _algorithm;

        private static IEnumerable<TestCaseData> IntersectCases()
        {
            yield return new TestCaseData(
                new Triangle(new PointF(0, 100), new PointF(100, 100), new PointF(50, 20)),
                new Circle(new PointF(100, 100), 50));
            yield return new TestCaseData(
                new Triangle(new PointF(100, 100), new PointF(200, 150), new PointF(150, 0)),
                new Circle(new PointF(100, 100), 50));
            yield return new TestCaseData(
                new Triangle(new PointF(100, 0), new PointF(170, 150), new PointF(150, 0)),
                new Circle(new PointF(100, 100), 50));
        }

        [Test]
        [TestCaseSource(nameof(IntersectCases))]
        public void TestIntersect(Polygon polygon, Circle circle)
        {
            Assert.That(_algorithm.IsIntersect(circle, polygon), Is.True);
        }

        private static IEnumerable<TestCaseData> InsideCases()
        {
            yield return new TestCaseData(
                new Triangle(new PointF(100, 60), new PointF(100, 140), new PointF(140, 100)),
                new Circle(new PointF(100, 100), 50));
            yield return new TestCaseData(
                new Triangle(new PointF(50, 0), new PointF(50, 200), new PointF(200, 100)),
                new Circle(new PointF(100, 100), 40));
        }

        [Test]
        [TestCaseSource(nameof(InsideCases))]
        public void TestInside(Polygon polygon, Circle circle)
        {
            Assert.That(_algorithm.IsIntersect(circle, polygon), Is.True);
        }

        private static IEnumerable<TestCaseData> DoNotIntersectCases()
        {
            yield return new TestCaseData(
                new Triangle(new PointF(0, 0), new PointF(40, 40), new PointF(200, 50)),
                new Circle(new PointF(100, 100), 50));
            yield return new TestCaseData(
                new Triangle(new PointF(0, 0), new PointF(50, 50), new PointF(200, 50)),
                new Circle(new PointF(100, 100), 50));
        }

        [Test]
        [TestCaseSource(nameof(DoNotIntersectCases))]
        public void TestDoNotIntersect(Polygon polygon, Circle circle)
        {
            Assert.That(_algorithm.IsIntersect(circle, polygon), Is.False);
        }
    }
}