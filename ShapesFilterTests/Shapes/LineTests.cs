using System.Collections.Generic;
using NUnit.Framework;
using ShapesFilter.Shapes;

namespace ShapesFilterTests.Shapes
{
    [TestFixture]
    public class LineTests
    {
        private static IEnumerable<TestCaseData> Cases()
        {
            yield return new TestCaseData(
                new Line(new PointF(10, 10), new PointF(0, 0)), new PointF(10, 10), new PointF(0, 0));
            yield return new TestCaseData(
                new Line(new PointF(0, 0), new PointF(10, 10)), new PointF(0, 0), new PointF(10, 10));
        }


        [Test]
        [TestCaseSource(nameof(Cases))]
        public void TestCreation(Line line, PointF p1, PointF p2)
        {
            Assert.That(line.ShapeType, Is.EqualTo(ShapeType.Line));
            Assert.That(line.P1.CompareTo(p1), Is.EqualTo(0));
            Assert.That(line.P2.CompareTo(p2), Is.EqualTo(0));
            Assert.That(line.Area, Is.LessThan(float.Epsilon));
        }
    }
}