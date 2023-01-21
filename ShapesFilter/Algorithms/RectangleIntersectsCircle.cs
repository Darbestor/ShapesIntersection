using System;
using ShapesFilter.Shapes;

namespace ShapesFilter.Algorithms
{
    public class RectangleIntersectsCircle : IIntersectValidator
    {
        public bool Intersect(IShape shape1, IShape shape2)
        {
            if (!(shape1 is Rectangle rect) || !(shape2 is Circle circle))
            {
                throw new ArgumentException("Wrong shapes");
            }

            // Find the closest point to the circle within the rectangle
            var closestX = Math.Clamp(circle.Center.X, rect.TopLeft.X, rect.BottomRight.X);
            var closestY = Math.Clamp(circle.Center.Y, rect.TopLeft.Y, rect.BottomRight.Y);

            // Calculate the distance between the circle's center and this closest point
            var distanceX = circle.Center.X - closestX;
            var distanceY = circle.Center.Y - closestY;

            // If the distance is less than the circle's radius, an intersection occurs
            var distanceSquared = distanceX * distanceX + distanceY * distanceY;
            return distanceSquared < circle.Radius * circle.Radius;
        }
    }
}