using ShapesFilter.Shapes;

namespace ShapesFilter.Algorithms
{
    public class AABBIntersectsAABB : IIntersectValidator
    {
        public bool Intersect(IShape shape1, IShape shape2)
        {
            var shapes = new ShapeCaster<BoundingBox, BoundingBox>(shape1, shape2);

            return !(shapes.Shape2.TopLeft.Y >= shapes.Shape1.BottomRight.Y ||
                     shapes.Shape2.BottomRight.Y <= shapes.Shape1.TopLeft.Y ||
                     shapes.Shape2.BottomRight.X <= shapes.Shape1.TopLeft.X ||
                     shapes.Shape2.TopLeft.X >= shapes.Shape1.BottomRight.X);
        }
    }
}