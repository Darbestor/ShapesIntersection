using System;
using ShapesFilter.Shapes;

namespace ShapesFilter.Algorithms
{
    /// <summary>
    ///     <see cref="Rectangle" /> to <see cref="Circle" /> intersection algorithm
    /// </summary>
    public class RectangleIntersectsCircle : IIntersectAlgorithm
    {
        public bool IsIntersect(IShape shape1, IShape shape2)
        {
            if (shape1 == null) throw new ArgumentNullException(nameof(shape1));
            if (shape2 == null) throw new ArgumentNullException(nameof(shape2));

            var shapes = new ShapeCaster<Circle, Rectangle>(shape1, shape2);

            // Find the closest point to the circle within the rectangle
            var closestX = Math.Clamp(shapes.Shape1.Center.X, shapes.Shape2.TopLeft.X, shapes.Shape2.BottomRight.X);
            var closestY = Math.Clamp(shapes.Shape1.Center.Y, shapes.Shape2.TopLeft.Y, shapes.Shape2.BottomRight.Y);

            // Calculate the distance between the circle's center and this closest point
            var distanceX = shapes.Shape1.Center.X - closestX;
            var distanceY = shapes.Shape1.Center.Y - closestY;

            // If the distance is less than the circle's radius, an intersection occurs
            var distanceSquared = distanceX * distanceX + distanceY * distanceY;
            return distanceSquared < shapes.Shape1.Radius * shapes.Shape1.Radius;
        }
    }
}