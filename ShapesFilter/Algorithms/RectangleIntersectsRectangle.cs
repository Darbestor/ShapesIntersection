using System;
using ShapesFilter.Shapes;

namespace ShapesFilter.Algorithms
{
    public class RectangleIntersectsRectangle : IIntersectValidator
    {
        public bool Intersect(IShape shape1, IShape shape2)
        {
            if (!(shape1 is BoundingBox rect1) || !(shape2 is BoundingBox rect2))
            {
                throw new ArgumentException("Wrong shapes");
            }

            return !(rect2.TopLeft.Y >= rect1.BottomRight.Y || rect2.BottomRight.Y <= rect1.TopLeft.Y ||
                     rect2.BottomRight.X <= rect1.TopLeft.X || rect2.TopLeft.X >= rect1.BottomRight.X);
        }
    }
}