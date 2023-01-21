using System.Collections.Generic;
using NUnit.Framework;
using ShapesFilter.Algorithms;
using ShapesFilter.Shapes;

namespace ShapesFilterTests.Algorithms
{
    public class LineIntersectsCircleTests
    {
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
            var alg = new LineIntersectsCircle();

            Assert.True(alg.Intersect(line, circle));
        }

        private static IEnumerable<TestCaseData> DoNotIntersectCases()
        {
            yield return new TestCaseData(new Line(50, 50, 150, 50), new Circle(new PointF(100, 100), 50));
            yield return new TestCaseData(new Line(50, 50, 50, 150), new Circle(new PointF(100, 100), 50));
            yield return new TestCaseData(new Line(0, 0, 20, 100), new Circle(new PointF(100, 100), 50));
            yield return new TestCaseData(new Line(0, 0, 40, 40), new Circle(new PointF(100, 100), 50));
        }

        [Test]
        [TestCaseSource(nameof(DoNotIntersectCases))]
        public void TestDoNotIntersect(Line line, Circle circle)
        {
            var alg = new LineIntersectsCircle();

            Assert.False(alg.Intersect(line, circle));
        }
    }
}