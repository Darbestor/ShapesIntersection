using System;
using ShapesFilter.Shapes;

namespace ShapesFilter.Algorithms
{
    public class LineIntersectsRectangle : IIntersectValidator<Line, Rectangle>
    {
        public bool Intersect(Line line, Rectangle rectangle)
        {
            // Find min and max X for the segment
            double minX = line.P1.X;
            double maxX = line.P2.X;

            if (line.P1.X > line.P2.X)
            {
                minX = line.P2.X;
                maxX = line.P1.X;
            }

            // Find the intersection of the segment's and rectangle's x-projections
            if (maxX > rectangle.BottomRight.X)
            {
                maxX = rectangle.BottomRight.X;
            }

            if (minX < rectangle.TopLeft.X)
            {
                minX = rectangle.TopLeft.X;
            }

            if (minX > maxX) // If their projections do not intersect return false
            {
                return false;
            }

            // Find corresponding min and max Y for min and max X we found before
            double minY = line.P1.Y;
            double maxY = line.P2.Y;

            double dx = line.P2.X - line.P1.X;

            if (Math.Abs(dx) > 0.0000001)
            {
                double a = (line.P2.Y - line.P1.Y) / dx;
                double b = line.P1.Y - a * line.P1.X;
                minY = a * minX + b;
                maxY = a * maxX + b;
            }

            if (minY > maxY)
            {
                (maxY, minY) = (minY, maxY);
            }

            // Find the intersection of the segment's and rectangle's y-projections
            if (maxY > rectangle.BottomRight.Y)
            {
                maxY = rectangle.BottomRight.Y;
            }

            if (minY < rectangle.TopLeft.Y)
            {
                minY = rectangle.TopLeft.Y;
            }

            if (minY > maxY) // If Y-projections do not intersect return false
            {
                return false;
            }

            return true;
        }
    }
}