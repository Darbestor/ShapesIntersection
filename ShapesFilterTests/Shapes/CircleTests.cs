using System;
using System.Collections.Generic;
using NUnit.Framework;
using ShapesFilter.Shapes;

namespace ShapesFilterTests.Shapes
{
    [TestFixture]
    public class CircleTests
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

        [Test]
        public void TestCreation()
        {
            var circle = new Circle(new PointF(1, 2), 3);
            Assert.That(circle.ShapeType, Is.EqualTo(ShapeType.Circle));
            Assert.That(circle.Center.X, Is.EqualTo(1));
            Assert.That(circle.Center.Y, Is.EqualTo(2));
            Assert.That(circle.Radius, Is.EqualTo(3));
        }

        [Test]
        public void TestWrongParameters()
        {
            Assert.Throws<ArgumentException>(() => new Circle(new PointF(0, 0), -1));
            Assert.Throws<ArgumentException>(() => new Circle(new PointF(0, 0), 0));
        }
    }
}