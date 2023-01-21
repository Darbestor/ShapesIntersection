using System;
using ShapesFilter.Shapes;

namespace ShapesFilter.Algorithms
{
    public class CircleIntersectsCircle : IIntersectValidator
    {
        public bool Intersect(IShape shape1, IShape shape2)
        {
            if (!(shape1 is Circle circle2) || !(shape2 is Circle circle1))
            {
                throw new ArgumentException("Wrong shapes");
            }

            return Math.Sqrt(Math.Pow(circle1.Center.X - circle2.Center.X, 2) +
                             Math.Pow(circle1.Center.Y - circle2.Center.Y, 2)) < circle1.Radius + circle2.Radius;
        }
    }
}