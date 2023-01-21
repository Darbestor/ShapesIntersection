using System;
using ShapesFilter.Shapes;

namespace ShapesFilter.Algorithms
{
    public class RectangleIntersectsRectangle : IIntersectValidator
    {
        private readonly AABBIntersectsAABB _aabbValidator;

        public RectangleIntersectsRectangle(AABBIntersectsAABB aabbValidator)
        {
            _aabbValidator = aabbValidator ?? throw new ArgumentNullException(nameof(aabbValidator));
        }

        public bool Intersect(IShape shape1, IShape shape2)
        {
            var shapes = new ShapeCaster<Rectangle, Rectangle>(shape1, shape2);

            return _aabbValidator.Intersect(shapes.Shape1.AABB, shapes.Shape2.AABB);
        }
    }
}