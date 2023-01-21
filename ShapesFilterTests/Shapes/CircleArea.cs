using System;
using System.Collections.Generic;
using NUnit.Framework;
using ShapesFilter.Shapes;

namespace ShapesFilterTests.Shapes
{
    [TestFixture]
    public class CircleArea
    {
        private static IEnumerable<TestCaseData> Cases()
        {
            yield return new TestCaseData(
                new Circle(new PointF(0, 0), 1), MathF.PI);
            yield return new TestCaseData(
                new Circle(new PointF(0, 0), 5), 78.539816f);
            yield return new TestCaseData(
                new Circle(new PointF(0, 0), 10), MathF.PI * 100);
            yield return new TestCaseData(
                new Circle(new PointF(0, 0), 37), 4300.840342f);
        }

        [Test]
        [TestCaseSource(nameof(Cases))]
        public void TestArea(Circle circle, float expected)
        {
            Assert.That(MathF.Abs(circle.Area - expected), Is.LessThan(float.Epsilon));
        }
    }
}