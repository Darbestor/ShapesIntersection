using ShapesFilter.Shapes;

namespace ShapesFilter.Algorithms
{
    /// <summary>
    /// Intersection algorithm
    /// </summary>
    public interface IIntersectAlgorithm
    {
        /// <summary>
        /// Check that 2 shapes are intersecting
        /// </summary>
        /// <param name="shape1">First shape</param>
        /// <param name="shape2">Second shape</param>
        /// <returns>Intersected flag</returns>
        bool IsIntersect(IShape shape1, IShape shape2);
    }
}