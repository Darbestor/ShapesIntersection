using System;
using System.Collections.Generic;
using NUnit.Framework;
using ShapesFilter.Shapes;

namespace ShapesFilterTests.Shapes
{
    [TestFixture]
    public class TriangleTests
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

        [Test]
        public void TestCreation()
        {
            var tr = new Triangle(new PointF(0, 0), new PointF(10, 10), new PointF(0, 10));
            Assert.That(tr.ShapeType, Is.EqualTo(ShapeType.Triangle));
            Assert.That(tr.Vertices.Length, Is.EqualTo(3));
            Assert.That(tr.Vertices[0].X, Is.EqualTo(0));
            Assert.That(tr.Vertices[0].Y, Is.EqualTo(0));
            Assert.That(tr.Vertices[1].X, Is.EqualTo(10));
            Assert.That(tr.Vertices[1].Y, Is.EqualTo(10));
            Assert.That(tr.Vertices[2].X, Is.EqualTo(0));
            Assert.That(tr.Vertices[2].Y, Is.EqualTo(10));
        }

        [Test]
        public void TestWrongParameters()
        {
            Assert.Throws<ArgumentException>(() => new Triangle());
            Assert.Throws<ArgumentException>(() => new Triangle(new PointF(0, 0)));
            Assert.Throws<ArgumentException>(() => new Triangle(new PointF(0, 0), new PointF(10, 10)));
            Assert.Throws<ArgumentException>(() =>
                new Triangle(new PointF(0, 0), new PointF(10, 10), new PointF(0, 10), new PointF(10, 15)));
        }
    }
}