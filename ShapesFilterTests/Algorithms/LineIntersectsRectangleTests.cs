using System.Collections.Generic;
using NUnit.Framework;
using ShapesFilter.Algorithms.LineIntersections;
using ShapesFilter.Shapes;

namespace ShapesFilterTests.Algorithms
{
    [TestFixture]
    public class LineIntersectsRectangleTests
    {
        [SetUp]
        public void Setup()
        {
            _algorithm = new LineIntersectsRectangle();
        }

        private LineIntersectsRectangle _algorithm;

        private static IEnumerable<TestCaseData> IntersectCases()
        {
            yield return new TestCaseData(new Line(150, 0, 150, 150), new Rectangle(100, 100, 100, 100));
            yield return new TestCaseData(new Line(150, 0, 150, 100), new Rectangle(100, 100, 100, 100));
            yield return new TestCaseData(new Line(150, 0, 150, 300), new Rectangle(100, 100, 100, 100));
            yield return new TestCaseData(new Line(120, 50, 70, 300), new Rectangle(100, 100, 100, 100));
        }

        [Test]
        [TestCaseSource(nameof(IntersectCases))]
        public void TestIntersect(Line line, Rectangle rectangle)
        {
            Assert.True(_algorithm.IsIntersect(line, rectangle));
        }

        [Test]
        public void TestContains()
        {
            var line = new Line(120, 110, 170, 180);
            var rect = new Rectangle(100, 100, 100, 100);

            Assert.True(_algorithm.IsIntersect(line, rect));
        }

        private static IEnumerable<TestCaseData> DoNotIntersectCases()
        {
            yield return new TestCaseData(new Line(100, 30, 30, 30), new Rectangle(100, 100, 100, 100));
            yield return new TestCaseData(new Line(100, 30, 200, 30), new Rectangle(100, 100, 100, 100));
            yield return new TestCaseData(new Line(99, 30, 99, 30), new Rectangle(100, 100, 100, 100));
        }

        [Test]
        [TestCaseSource(nameof(DoNotIntersectCases))]
        public void TestDoNotIntersect(Line line, Rectangle rectangle)
        {
            Assert.False(_algorithm.IsIntersect(line, rectangle));
        }
    }
}