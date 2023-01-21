using System.Collections.Generic;
using NUnit.Framework;
using ShapesFilter.Algorithms;
using ShapesFilter.Algorithms.LineIntersections;
using ShapesFilter.Algorithms.PointInside;
using ShapesFilter.Shapes;

namespace ShapesFilterTests.Algorithms
{
    [TestFixture]
    public class PolygonIntersectsPolygonTests
    {
        [SetUp]
        public void Setup()
        {
            _algorithm = new PolygonIntersectsPolygon(new RectangleIntersectsRectangle(), new LineIntersectsLine(),
                new PointInsidePolygon());
        }

        private PolygonIntersectsPolygon _algorithm;

        private static IEnumerable<TestCaseData> IntersectCases()
        {
            yield return new TestCaseData(
                new Rectangle(50, 100, 100, 100),
                new Triangle(new PointF(100, 200), new PointF(200, 200), new PointF(100, 100)));
            yield return new TestCaseData(
                new Rectangle(150, 120, 100, 100),
                new Triangle(new PointF(100, 200), new PointF(200, 200), new PointF(100, 100)));
            yield return new TestCaseData(
                new Rectangle(150, 20, 100, 100),
                new Triangle(new PointF(100, 200), new PointF(200, 200), new PointF(100, 100)));
            yield return new TestCaseData(
                new Rectangle(50, 20, 100, 100),
                new Triangle(new PointF(100, 200), new PointF(200, 200), new PointF(100, 100)));
        }

        [Test]
        [TestCaseSource(nameof(IntersectCases))]
        public void TestIntersect(Polygon p1, Polygon p2)
        {
            Assert.That(_algorithm.Intersect(p1, p2), Is.True);
        }

        private static IEnumerable<TestCaseData> InsideCases()
        {
            yield return new TestCaseData(
                new Rectangle(100, 100, 100, 100),
                new Triangle(new PointF(101, 101), new PointF(199, 199), new PointF(199, 101)));
            yield return new TestCaseData(
                new Rectangle(100, 100, 100, 100),
                new Triangle(new PointF(120, 120), new PointF(180, 180), new PointF(180, 120)));
            yield return new TestCaseData(
                new Rectangle(100, 100, 100, 100),
                new Triangle(new PointF(0, 0), new PointF(0, 300), new PointF(150, 150)));
        }

        [Test]
        [TestCaseSource(nameof(InsideCases))]
        public void TestInside(Polygon p1, Polygon p2)
        {
            Assert.That(_algorithm.Intersect(p1, p2), Is.True);
        }

        private static IEnumerable<TestCaseData> DoNotIntersect()
        {
            yield return new TestCaseData(
                new Rectangle(100, 100, 100, 100),
                new Triangle(new PointF(0, 100), new PointF(100, 100), new PointF(50, 20)));
            yield return new TestCaseData(
                new Rectangle(100, 0, 100, 100),
                new Triangle(new PointF(0, 100), new PointF(100, 100), new PointF(50, 20)));
            yield return new TestCaseData(
                new Rectangle(100, 0, 100, 100),
                new Triangle(new PointF(0, 100), new PointF(100, 100), new PointF(50, 20)));
            yield return new TestCaseData(
                new Rectangle(50, 30, 100, 100),
                new Triangle(new PointF(100, 200), new PointF(200, 200), new PointF(150, 120)));
            yield return new TestCaseData(
                new Rectangle(50, 170, 100, 100),
                new Triangle(new PointF(100, 200), new PointF(200, 200), new PointF(150, 120)));
        }

        [Test]
        [TestCaseSource(nameof(DoNotIntersect))]
        public void TestDoNotIntersect(Polygon p1, Polygon p2)
        {
            Assert.That(_algorithm.Intersect(p1, p2), Is.False);
        }
    }
}