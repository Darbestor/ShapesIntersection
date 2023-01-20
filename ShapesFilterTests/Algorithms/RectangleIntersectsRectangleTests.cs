using System.Collections.Generic;
using NUnit.Framework;
using ShapesFilter;
using ShapesFilter.Algorithm;
using ShapesFilter.Algorithms;
using ShapesFilter.Shapes;

namespace ShapesFilterTests.Algorithm
{
    public class RectangleIntersectsRectangleTests
    {
        private static IEnumerable<TestCaseData> IntersectCases()
        {
            yield return new TestCaseData(
                new Rectangle(100, 50, 100, 100),
                new Rectangle(100, 100, 100, 100));
            yield return new TestCaseData(
                new Rectangle(100, 150, 100, 100),
                new Rectangle(100, 100, 100, 100));
            yield return new TestCaseData(
                new Rectangle(50, 100, 100, 100),
                new Rectangle(100, 100, 100, 100));
            yield return new TestCaseData(
                new Rectangle(150, 100, 100, 100),
                new Rectangle(100, 100, 100, 100));
            yield return new TestCaseData(
                new Rectangle(150, 150, 100, 100),
                new Rectangle(100, 100, 100, 100));
            yield return new TestCaseData(
                new Rectangle(50, 50, 100, 100),
                new Rectangle(100, 100, 100, 100));
            yield return new TestCaseData(
                new Rectangle(199, 150, 100, 100),
                new Rectangle(100, 100, 100, 100));
        }

        [Test]
        [TestCaseSource(nameof(IntersectCases))]
        public void TestIntersect(Rectangle r1, Rectangle r2)
        {
            var alg = new RectangleIntersectsRectangle();

            Assert.True(alg.Intersect(r1.AABB, r2.AABB));
        }

        private static IEnumerable<TestCaseData> InsideCases()
        {
            yield return new TestCaseData(
                new Rectangle(120, 120, 50, 50),
                new Rectangle(100, 100, 100, 100));
            yield return new TestCaseData(
                new Rectangle(101, 101, 99, 99),
                new Rectangle(100, 100, 100, 100));
        }

        [Test]
        [TestCaseSource(nameof(InsideCases))]
        public void TestInside(Rectangle r1, Rectangle r2)
        {
            var alg = new RectangleIntersectsRectangle();

            Assert.True(alg.Intersect(r1.AABB, r2.AABB));
        }

        private static IEnumerable<TestCaseData> DoNotIntersectCases()
        {
            yield return new TestCaseData(
                new Rectangle(100, 100, 100, 100),
                new Rectangle(200, 200, 100, 100));
            yield return new TestCaseData(
                new Rectangle(200, 100, 100, 100),
                new Rectangle(200, 200, 100, 100));
            yield return new TestCaseData(
                new Rectangle(100, 200, 100, 100),
                new Rectangle(200, 200, 100, 100));
            yield return new TestCaseData(
                new Rectangle(300, 200, 100, 100),
                new Rectangle(200, 200, 100, 100));
            yield return new TestCaseData(
                new Rectangle(200, 300, 100, 100),
                new Rectangle(200, 200, 100, 100));
        }

        [Test]
        [TestCaseSource(nameof(InsideCases))]
        public void TestDoNotIntersect(Rectangle r1, Rectangle r2)
        {
            var alg = new RectangleIntersectsRectangle();

            Assert.True(alg.Intersect(r1.AABB, r2.AABB));
        }
    }
}