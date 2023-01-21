using System;
using ShapesFilter.Shapes;

namespace ShapesFilter.Algorithms
{
    public class CircleIntersectsCircle : IIntersectValidator<Circle, Circle>
    {
        public bool Intersect(Circle circle1, Circle circle2)
        {
            return Math.Sqrt(Math.Pow(circle1.Center.X - circle2.Center.X, 2) +
                             Math.Pow(circle1.Center.Y - circle2.Center.Y, 2)) < (circle1.Radius + circle2.Radius);
        }
    }
}