using System.Collections.Generic;
using ShapesFilter.Shapes;

namespace ShapesFilter.Algorithms.PointInside
{
    public class PointInsidePolygon : IPointInside<Polygon>
    {
        public bool IsInside(PointF target, Polygon shape)
        {
            return IsInside(shape.Vertices, target);
        }

        private bool IsInside(IReadOnlyList<PointF> polygon, PointF point)
        {
            bool result = false;
            int j = polygon.Count - 1;
            for (int i = 0; i < polygon.Count; i++)
            {
                if (polygon[i].Y < point.Y && polygon[j].Y >= point.Y ||
                    polygon[j].Y < point.Y && polygon[i].Y >= point.Y)
                {
                    if (polygon[i].X + (point.Y - polygon[i].Y) / (polygon[j].Y - polygon[i].Y) *
                        (polygon[j].X - polygon[i].X) < point.X)
                    {
                        result = !result;
                    }
                }

                j = i;
            }

            return result;
        }
    }
}