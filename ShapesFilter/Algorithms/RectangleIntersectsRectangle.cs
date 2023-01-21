using ShapesFilter.Shapes;

namespace ShapesFilter.Algorithms
{
    public class RectangleIntersectsRectangle : IIntersectValidator<BoundingBox, BoundingBox>
    {
        public bool Intersect(BoundingBox rect1, BoundingBox rect2)
        {
            return !(rect2.TopLeft.Y >= rect1.BottomRight.Y || rect2.BottomRight.Y <= rect1.TopLeft.Y ||
                     rect2.BottomRight.X <= rect1.TopLeft.X || rect2.TopLeft.X >= rect1.BottomRight.X);
        }
    }
}