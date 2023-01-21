using System;
using ShapesFilter.Shapes;

namespace ShapesFilter.Algorithms.PointInside
{
    public class PointInsideCircle : IPointInside<Circle>
    {
        public bool IsInside(PointF target, Circle shape)
        {
            // get distance between the point and circle's center
            // using the Pythagorean Theorem
            var distX = target.X - shape.Center.X;
            var distY = target.Y - shape.Center.Y;
            var distance = MathF.Sqrt(distX * distX + distY * distY);

            // if the distance is less than the circle's 
            // radius the point is inside!
            return distance <= shape.Radius;
        }
    }
}