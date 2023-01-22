using System;
using System.Collections.Generic;
using NUnit.Framework;
using ShapesFilter.Shapes;

namespace ShapesFilterTests.Shapes
{
    [TestFixture]
    public class PointFTests
    {
        private static IEnumerable<TestCaseData> Cases()
        {
            yield return new TestCaseData(new PointF(10, 10), 10, 10);
            yield return new TestCaseData(new PointF(0, 0), 0, 0);
            yield return new TestCaseData(new PointF(0, 10), 0, 10);
            yield return new TestCaseData(new PointF(10, 0), 10, 0);
        }


        [Test]
        [TestCaseSource(nameof(Cases))]
        public void TestCreation(PointF point, float x, float y)
        {
            Assert.That(MathF.Abs(point.X - x), Is.LessThan(float.Epsilon));
            Assert.That(MathF.Abs(point.Y - y), Is.LessThan(float.Epsilon));
        }

        [Test]
        public void TestWrongParameters()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new PointF(-1, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => new PointF(0, -1));
            Assert.Throws<ArgumentOutOfRangeException>(() => new PointF(0, float.NaN));
            Assert.Throws<ArgumentOutOfRangeException>(() => new PointF(float.NaN, 0));
        }
    }
}