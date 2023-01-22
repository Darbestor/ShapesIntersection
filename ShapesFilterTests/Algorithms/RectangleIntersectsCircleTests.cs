using System.Collections.Generic;
using NUnit.Framework;
using ShapesFilter.Algorithms;
using ShapesFilter.Shapes;

namespace ShapesFilterTests.Algorithms
{
    public class RectangleIntersectsCircleTests
    {
        private static IEnumerable<TestCaseData> IntersectCases()
        {
            yield return new TestCaseData(
                new Rectangle(200, 200, 100, 100),
                new Circle(new PointF(200, 250), 40));
            yield return new TestCaseData(
                new Rectangle(200, 200, 100, 100),
                new Circle(new PointF(250, 200), 40));
            yield return new TestCaseData(
                new Rectangle(200, 200, 100, 100),
                new Circle(new PointF(210, 200), 40));
            yield return new TestCaseData(
                new Rectangle(200, 200, 100, 100),
                new Circle(new PointF(170, 180), 40));
        }

        [Test]
        [TestCaseSource(nameof(IntersectCases))]
        public void TestIntersect(Rectangle rect, Circle circle)
        {
            var alg = new RectangleIntersectsCircle();

            Assert.True(alg.IsIntersect(rect, circle));
        }

        private static IEnumerable<TestCaseData> ContainsCases()
        {
            yield return new TestCaseData(
                new Rectangle(200, 200, 100, 100),
                new Circle(new PointF(250, 250), 40));
        }

        [Test]
        [TestCaseSource(nameof(IntersectCases))]
        public void TestContains(Rectangle rect, Circle circle)
        {
            var alg = new RectangleIntersectsCircle();

            Assert.True(alg.IsIntersect(rect, circle));
        }

        private static IEnumerable<TestCaseData> DoNotIntersect()
        {
            yield return new TestCaseData(
                new Rectangle(200, 200, 100, 100),
                new Circle(new PointF(250, 160), 40));
        }

        [Test]
        [TestCaseSource(nameof(DoNotIntersect))]
        public void TestDoNotIntersect(Rectangle rect, Circle circle)
        {
            var alg = new RectangleIntersectsCircle();

            Assert.False(alg.IsIntersect(rect, circle));
        }
    }
}