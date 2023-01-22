using System;
using ShapesFilter.Shapes;

namespace ShapesFilter.Algorithms
{
    /// <summary>
    ///     <see cref="Rectangle" /> to <see cref="Rectangle" /> intersection algorithm
    /// </summary>
    public class RectangleIntersectsRectangle : IIntersectAlgorithm
    {
        private readonly AABBIntersectsAABB _aabbValidator;

        public RectangleIntersectsRectangle(AABBIntersectsAABB aabbValidator)
        {
            _aabbValidator = aabbValidator ?? throw new ArgumentNullException(nameof(aabbValidator));
        }

        public bool IsIntersect(IShape shape1, IShape shape2)
        {
            if (shape1 == null) throw new ArgumentNullException(nameof(shape1));
            if (shape2 == null) throw new ArgumentNullException(nameof(shape2));

            var shapes = new ShapeCaster<Rectangle, Rectangle>(shape1, shape2);

            return _aabbValidator.IsIntersect(shapes.Shape1.AABB, shapes.Shape2.AABB);
        }
    }
}