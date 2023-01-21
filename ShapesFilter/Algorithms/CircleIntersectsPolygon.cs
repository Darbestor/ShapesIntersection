using System.Collections.Generic;
using ShapesFilter.Shapes;

namespace ShapesFilter.Algorithms
{
    public class CircleIntersectsPolygon : IIntersectValidator<Circle, Polygon>
    {
        private readonly LineIntersectsCircle _lineCircleValidator;

        public CircleIntersectsPolygon(LineIntersectsCircle lineCircleValidator)
        {
            _lineCircleValidator = lineCircleValidator;
        }

        public bool Intersect(Circle circle, Polygon polygon)
        {
            var vertices = polygon.Vertices;
            for (int i = 0; i < vertices.Length; i++)
            {
                var nextVertex = (i + 1) % 3;
                if (_lineCircleValidator.Intersect(new Line(vertices[i], vertices[nextVertex]), circle))
                {
                    return true;
                }
            }

            return IsInside(vertices, circle.Center);
        }

        //TODO Refactor
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