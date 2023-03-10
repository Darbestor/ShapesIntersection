using System.Collections.Generic;
using NUnit.Framework;
using ShapesFilter.Algorithms;
using ShapesFilter.Shapes;

namespace ShapesFilterTests.Algorithms
{
    [TestFixture]
    public class CircleIntersectsCircleTests
    {
        [SetUp]
        public void Setup()
        {
            _algorithm = new CircleIntersectsCircle();
        }

        private CircleIntersectsCircle _algorithm;

        private static IEnumerable<TestCaseData> IntersectCases()
        {
            yield return new TestCaseData(
                new Circle(new PointF(200, 250), 50),
                new Circle(new PointF(200, 200), 50));
            yield return new TestCaseData(
                new Circle(new PointF(250, 200), 50),
                new Circle(new PointF(200, 200), 50));
            yield return new TestCaseData(
                new Circle(new PointF(250, 250), 50),
                new Circle(new PointF(200, 200), 50));
        }

        [Test]
        [TestCaseSource(nameof(IntersectCases))]
        public void TestIntersect(Circle c1, Circle c2)
        {
            Assert.True(_algorithm.IsIntersect(c1, c2));
        }

        private static IEnumerable<TestCaseData> InsideCases()
        {
            yield return new TestCaseData(
                new Circle(new PointF(200, 200), 50),
                new Circle(new PointF(200, 200), 50));
            yield return new TestCaseData(
                new Circle(new PointF(200, 200), 100),
                new Circle(new PointF(200, 200), 50));
            yield return new TestCaseData(
                new Circle(new PointF(200, 200), 50),
                new Circle(new PointF(200, 200), 100));
            yield return new TestCaseData(
                new Circle(new PointF(225, 200), 20),
                new Circle(new PointF(200, 200), 50));
            yield return new TestCaseData(
                new Circle(new PointF(200, 200), 50),
                new Circle(new PointF(225, 200), 20));
        }

        [Test]
        [TestCaseSource(nameof(InsideCases))]
        public void TestInside(Circle c1, Circle c2)
        {
            Assert.True(_algorithm.IsIntersect(c1, c2));
        }

        private static IEnumerable<TestCaseData> DoNotOverlapCases()
        {
            yield return new TestCaseData(
                new Circle(new PointF(300, 200), 50),
                new Circle(new PointF(200, 200), 50));
            yield return new TestCaseData(
                new Circle(new PointF(200, 300), 50),
                new Circle(new PointF(200, 200), 50));
            yield return new TestCaseData(
                new Circle(new PointF(250, 290), 50),
                new Circle(new PointF(200, 200), 50));
        }

        [Test]
        [TestCaseSource(nameof(DoNotOverlapCases))]
        public void TestDoNotOverlap(Circle c1, Circle c2)
        {
            Assert.False(_algorithm.IsIntersect(c1, c2));
        }
    }
}