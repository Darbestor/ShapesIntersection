using NUnit.Framework;
using ShapesFilter.Algorithm;
using ShapesFilter.Shapes;

namespace ShapesFilterTests.Algorithms
{
    public class LineIntersectsLineTests
    {
        [Test]
        public void TestParallel()
        {
            var l1 = new Line(10, 10, 100, 100);
            var l2 = new Line(20, 10, 110, 100);

            var alg = new LineIntersectsLine();
            Assert.False(alg.Intersect(l1, l2));
        }
        
        [Test]
        public void TestIntersect()
        {
            var l1 = new Line(10, 10, 100, 100);
            var l2 = new Line(20, 40, 110, 50);

            var alg = new LineIntersectsLine();
            Assert.True(alg.Intersect(l1, l2));


            l2 = l1;
            Assert.True(alg.Intersect(l1, l2));
        }
    }
}