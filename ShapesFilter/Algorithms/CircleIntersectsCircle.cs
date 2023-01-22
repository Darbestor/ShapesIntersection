using System;
using ShapesFilter.Shapes;

namespace ShapesFilter.Algorithms
{
    /// <summary>
    /// <see cref="Circle"/> to <see cref="Circle"/> intersection algorithm
    /// </summary>
    public class CircleIntersectsCircle : IIntersectAlgorithm
    {
        public bool IsIntersect(IShape shape1, IShape shape2)
        {
            if (shape1 == null) throw new ArgumentNullException(nameof(shape1));
            if (shape2 == null) throw new ArgumentNullException(nameof(shape2));

            var shapes = new ShapeCaster<Circle, Circle>(shape1, shape2);

            return Math.Sqrt(Math.Pow(shapes.Shape1.Center.X - shapes.Shape2.Center.X, 2) +
                             Math.Pow(shapes.Shape1.Center.Y - shapes.Shape2.Center.Y, 2)) <
                   shapes.Shape1.Radius + shapes.Shape2.Radius;
        }
    }
}