using ShapesFilter.Shapes;

namespace ShapesFilter.Algorithms
{
    public interface IIntersectValidator
    {
        bool Intersect(IShape shape1, IShape shape2);
    }
}