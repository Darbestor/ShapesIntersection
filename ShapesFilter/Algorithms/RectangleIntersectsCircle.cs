using System;
using ShapesFilter.Shapes;

namespace ShapesFilter.Algorithms
{
    public class RectangleIntersectsCircle : IIntersectValidator<Rectangle, Circle>
    {
        public bool Intersect(Rectangle rect, Circle circle)
        {
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