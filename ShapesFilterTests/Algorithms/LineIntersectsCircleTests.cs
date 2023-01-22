using System.Collections.Generic;
using NUnit.Framework;
using ShapesFilter.Algorithms.LineIntersections;
using ShapesFilter.Algorithms.PointInside;
using ShapesFilter.Shapes;

namespace ShapesFilterTests.Algorithms
{
    [TestFixture]
    public class LineIntersectsCircleTests
    {
        [SetUp]
        public void Setup()
        {
            _algorithm = new LineIntersectsCircle(new PointInsideCircle());
        }

        private LineIntersectsCircle _algorithm;

        private static IEnumerable<TestCaseData> IntersectCases()
        {
            yield return new TestCaseData(new Line(50, 50, 100, 100), new Circle(new PointF(100, 100), 50));
            yield return new TestCaseData(new Line(50, 50, 150, 150), new Circle(new PointF(100, 100), 50));
            yield return new TestCaseData(new Line(90, 90, 120, 120), new Circle(new PointF(100, 100), 50));
        }

        [Test]
        [TestCaseSource(nameof(IntersectCases))]
        public void TestIntersect(Line line, Circle circle)
        {
            var alg = new LineIntersectsCircle(new PointInsideCircle());

            Assert.True(alg.IsIntersect(line, circle));
        }

        private static IEnumerable<TestCaseData> InsideCases()
        {
            yield return new TestCaseData(new Line(50, 50, 50, 150), new Circle(new PointF(100, 100), 100));
            yield return new TestCaseData(new Line(50, 150, 150, 50), new Circle(new PointF(100, 100), 100));
            yield return new TestCaseData(new Line(50, 150, 150, 150), new Circle(new PointF(100, 100), 100));
        }

        [Test]
        [TestCaseSource(nameof(InsideCases))]
        public void TestInside(Line line, Circle circle)
        {
            Assert.True(_algorithm.IsIntersect(line, circle));
        }

        private static IEnumerable<TestCaseData> DoNotIntersectCases()
        {
            yield return new TestCaseData(new Line(50, 50, 150, 50), new Circle(new PointF(100, 100), 50));
            yield return new TestCaseData(new Line(50, 50, 50, 150), new Circle(new PointF(100, 100), 50));
            yield return new TestCaseData(new Line(50, 150, 50, 50), new Circle(new PointF(100, 100), 50));
            yield return new TestCaseData(new Line(0, 0, 20, 100), new Circle(new PointF(100, 100), 50));
            yield return new TestCaseData(new Line(0, 0, 40, 40), new Circle(new PointF(100, 100), 50));
            yield return new TestCaseData(new Line(40, 20, 0, 0), new Circle(new PointF(100, 100), 50));
        }

        [Test]
        [TestCaseSource(nameof(DoNotIntersectCases))]
        public void TestDoNotIntersect(Line line, Circle circle)
        {
            Assert.False(_algorithm.IsIntersect(line, circle));
        }
    }
}