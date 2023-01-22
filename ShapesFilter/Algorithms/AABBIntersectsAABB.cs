using System;
using ShapesFilter.Shapes;

namespace ShapesFilter.Algorithms
{
    /// <summary>
    ///     <see cref="BoundingBox" /> to <see cref="BoundingBox" /> intersection algorithm
    /// </summary>
    public class AABBIntersectsAABB : IIntersectAlgorithm
    {
        public bool IsIntersect(IShape shape1, IShape shape2)
        {
            if (shape1 == null) throw new ArgumentNullException(nameof(shape1));
            if (shape2 == null) throw new ArgumentNullException(nameof(shape2));

            var shapes = new ShapeCaster<BoundingBox, BoundingBox>(shape1, shape2);

            return !(shapes.Shape2.TopLeft.Y >= shapes.Shape1.BottomRight.Y ||
                     shapes.Shape2.BottomRight.Y <= shapes.Shape1.TopLeft.Y ||
                     shapes.Shape2.BottomRight.X <= shapes.Shape1.TopLeft.X ||
                     shapes.Shape2.TopLeft.X >= shapes.Shape1.BottomRight.X);
        }
    }
}