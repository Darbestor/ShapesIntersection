using System.Collections.Generic;
using NUnit.Framework;
using ShapesFilter.Algorithms.LineIntersections;
using ShapesFilter.Algorithms.PointInside;
using ShapesFilter.Shapes;

namespace ShapesFilterTests.Algorithms
{
    [TestFixture]
    public class LineIntersectsTriangleTests
    {
        [SetUp]
        public void Setup()
        {
            _algorithm = new LineIntersectsTriangle(new LineIntersectsLine(), new PointInsideTriangle());
        }

        private LineIntersectsTriangle _algorithm;

        private static IEnumerable<TestCaseData> IntersectCases()
        {
            yield return new TestCaseData(new Line(0, 0, 100, 150),
                new Triangle(new PointF(0, 100), new PointF(100, 100), new PointF(50, 20)));
            yield return new TestCaseData(new Line(0, 0, 100, 100),
                new Triangle(new PointF(0, 100), new PointF(100, 100), new PointF(50, 20)));
            yield return new TestCaseData(new Line(0, 100, 100, 100),
                new Triangle(new PointF(0, 100), new PointF(100, 100), new PointF(50, 20)));
        }

        [Test]
        [TestCaseSource(nameof(IntersectCases))]
        public void TestIntersect(Line line, Triangle triangle)
        {
            Assert.True(_algorithm.IsIntersect(line, triangle));
        }

        private static IEnumerable<TestCaseData> ContainsCases()
        {
            yield return new TestCaseData(new Line(40, 50, 80, 80),
                new Triangle(new PointF(0, 100), new PointF(100, 100), new PointF(50, 20)));
            yield return new TestCaseData(new Line(1, 99, 99, 99),
                new Triangle(new PointF(0, 100), new PointF(100, 100), new PointF(50, 20)));
            yield return new TestCaseData(new Line(35, 50, 65, 50),
                new Triangle(new PointF(0, 100), new PointF(100, 100), new PointF(50, 20)));
        }

        [Test]
        [TestCaseSource(nameof(ContainsCases))]
        public void TestContains(Line line, Triangle triangle)
        {
            Assert.True(_algorithm.IsIntersect(line, triangle));
        }

        private static IEnumerable<TestCaseData> DoNotIntersectCases()
        {
            yield return new TestCaseData(new Line(49, 20, 0, 99),
                new Triangle(new PointF(0, 100), new PointF(100, 100), new PointF(50, 20)));
            yield return new TestCaseData(new Line(0, 101, 100, 101),
                new Triangle(new PointF(0, 100), new PointF(100, 100), new PointF(50, 20)));
        }

        [Test]
        [TestCaseSource(nameof(DoNotIntersectCases))]
        public void TestDoNotContains(Line line, Triangle triangle)
        {
            Assert.False(_algorithm.IsIntersect(line, triangle));
        }
    }
}