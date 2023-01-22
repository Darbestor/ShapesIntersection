using ShapesFilter.Shapes;

namespace ShapesFilter.Algorithms.PointInside
{
    /// <summary>
    /// Check if point is inside shape
    /// </summary>
    public interface IPointInside<T> where T : IShape
    {
        bool IsInside(PointF target, T shape);
    }
}