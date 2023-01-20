using ShapesFilter.Shapes;

namespace ShapesFilter.Algorithm
{
    public interface IIntersectValidator<S1, S2>
        where S1 : IShape
        where S2 : IShape
    {
        bool Intersect(S1 shape1, S2 shape2);
    }
}