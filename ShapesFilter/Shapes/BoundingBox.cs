using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ShapesFilter.Shapes;

namespace ShapesFilter
{
    public class BoundingBox: IShape
    {
        public PointF TopLeft { get; }
        public PointF BottomRight { get; }

        internal BoundingBox(PointF topLeft, PointF bottomRight)
        {
            TopLeft = topLeft;
            BottomRight = bottomRight;
        }
        
        internal BoundingBox(float minX, float minY, float maxX, float maxY): this(new PointF(minX, minY), new PointF(maxX, maxY))
        {
        }
        
        internal BoundingBox(IEnumerable<PointF> vertices)
        {
            var minX = float.MaxValue;
            var minY = float.MaxValue;
            var maxX = float.MinValue;
            var maxY = float.MinValue;

            foreach (var v in vertices)
            {
                if (v.X < minX)
                {
                    minX = v.X;
                }

                if (v.X > maxX)
                {
                    maxX = v.X;
                }

                if (v.Y < minY)
                {
                    minY = v.Y;
                }

                if (v.Y > maxY)
                {
                    maxY = v.Y;
                }
            }

            TopLeft = new PointF(minX, minY);
            BottomRight = new PointF(maxX, maxY);
        }
    }
}