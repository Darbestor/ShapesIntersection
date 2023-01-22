using NUnit.Framework;
using ShapesFilter.Algorithms.LineIntersections;
using ShapesFilter.Shapes;

namespace ShapesFilterTests.Algorithms
{
    [TestFixture]
    public class LineIntersectsLineTests
    {
        [SetUp]
        public void Setup()
        {
            _algorithm = new LineIntersectsLine();
        }

        private LineIntersectsLine _algorithm;

        [Test]
        public void TestParallel()
        {
            var l1 = new Line(10, 10, 100, 100);
            var l2 = new Line(20, 10, 110, 100);

            var alg = new LineIntersectsLine();
            Assert.False(alg.IsIntersect(l1, l2));
        }

        [Test]
        public void TestIntersect()
        {
            var l1 = new Line(10, 10, 100, 100);
            var l2 = new Line(20, 40, 110, 50);

            Assert.True(_algorithm.IsIntersect(l1, l2));


            l2 = l1;
            Assert.True(_algorithm.IsIntersect(l1, l2));
        }
    }
}