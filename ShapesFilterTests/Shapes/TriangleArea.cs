using System;
using System.Collections.Generic;
using NUnit.Framework;
using ShapesFilter.Shapes;

namespace ShapesFilterTests.Shapes
{
    [TestFixture]
    public class TriangleArea
    {
        private static IEnumerable<TestCaseData> Cases()
        {
            yield return new TestCaseData(
                new Triangle(new PointF(0, 0), new PointF(0, 100), new PointF(100, 100)), 5000f);
            yield return new TestCaseData(
                new Triangle(new PointF(0, 0), new PointF(30, 100), new PointF(100, 50)), 4250f);
        }

        [Test]
        [TestCaseSource(nameof(Cases))]
        public void TestArea(Triangle triangle, float expected)
        {
            Assert.That(MathF.Abs(triangle.Area - expected), Is.LessThan(float.Epsilon));
        }
    }
}