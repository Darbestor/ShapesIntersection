using System;
using ShapesFilter.Shapes;

namespace ShapesFilter.Algorithms.LineIntersections
{
    public class LineIntersectsRectangle : IIntersectValidator
    {
        public bool Intersect(IShape shape1, IShape shape2)
        {
            var shapes = new ShapeCaster<Line, Rectangle>(shape1, shape2);

            // Find min and max X for the segment
            double minX = shapes.Shape1.P1.X;
            double maxX = shapes.Shape1.P2.X;

            if (shapes.Shape1.P1.X > shapes.Shape1.P2.X)
            {
                minX = shapes.Shape1.P2.X;
                maxX = shapes.Shape1.P1.X;
            }

            // Find the intersection of the segment's and rectangle's x-projections
            if (maxX > shapes.Shape2.BottomRight.X) maxX = shapes.Shape2.BottomRight.X;

            if (minX < shapes.Shape2.TopLeft.X) minX = shapes.Shape2.TopLeft.X;

            if (minX > maxX) // If their projections do not intersect return false
                return false;

            // Find corresponding min and max Y for min and max X we found before
            double minY = shapes.Shape1.P1.Y;
            double maxY = shapes.Shape1.P2.Y;

            double dx = shapes.Shape1.P2.X - shapes.Shape1.P1.X;

            if (Math.Abs(dx) > 0.0000001)
            {
                var a = (shapes.Shape1.P2.Y - shapes.Shape1.P1.Y) / dx;
                var b = shapes.Shape1.P1.Y - a * shapes.Shape1.P1.X;
                minY = a * minX + b;
                maxY = a * maxX + b;
            }

            if (minY > maxY) (maxY, minY) = (minY, maxY);

            // Find the intersection of the segment's and rectangle's y-projections
            if (maxY > shapes.Shape2.BottomRight.Y) maxY = shapes.Shape2.BottomRight.Y;

            if (minY < shapes.Shape2.TopLeft.Y) minY = shapes.Shape2.TopLeft.Y;

            if (minY > maxY) // If Y-projections do not intersect return false
                return false;

            return true;
        }
    }
}