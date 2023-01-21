using System;
using System.Collections.Generic;
using NUnit.Framework;
using ShapesFilter.Shapes;

namespace ShapesFilterTests.Shapes
{
    [TestFixture]
    public class RectangleArea
    {
        private static IEnumerable<TestCaseData> Cases()
        {
            yield return new TestCaseData(
                new Rectangle(new PointF(0, 0), new PointF(100, 100)), 10000f);
            yield return new TestCaseData(
                new Rectangle(new PointF(0, 40), new PointF(100, 100)), 6000f);
            yield return new TestCaseData(
                new Rectangle(new PointF(40, 0), new PointF(100, 100)), 6000f);
        }

        [Test]
        [TestCaseSource(nameof(Cases))]
        public void TestArea(Rectangle rectangle, float expected)
        {
            Assert.That(MathF.Abs(rectangle.Area - expected), Is.LessThan(float.Epsilon));
        }
    }
}