using ShapesFilter.Algorithm;
using ShapesFilter.Shapes;

namespace ShapesFilter.Algorithms
{
    public class LineIntersectsTriangle: IIntersectValidator<Line, Triangle>
    {
        private readonly LineIntersectsLine _lineIntersectValidator;

        public LineIntersectsTriangle(LineIntersectsLine lineIntersectValidator)
        {
            _lineIntersectValidator = lineIntersectValidator;
        }

        private bool IsInside(PointF target, Triangle triangle)
        {
            var v1 = triangle.Vertices[0];
            var v2 = triangle.Vertices[1];
            var v3 = triangle.Vertices[2];
            
            var s = (v1.X - v3.X) * (target.Y - v3.Y) - (v1.Y - v3.Y) * (target.X - v3.X);
            var t = (v2.X - v1.X) * (target.Y - v1.Y) - (v2.Y - v1.Y) * (target.X - v1.X);

            if ((s < 0) != (t < 0) && s != 0 && t != 0)
                return false;

            var d = (v3.X - v2.X) * (target.Y - v2.Y) - (v3.Y - v2.Y) * (target.X - v2.X);
            return d == 0 || (d < 0) == (s + t <= 0);
        }

        
        public bool Intersect(Line line, Triangle triangle)
        {
            return Intersect(line.P1, line.P2, triangle);
        }
        
        public bool Intersect(PointF point1, PointF point2, Triangle triangle)
        {
            var vertices = triangle.Vertices;
            for (int i = 0; i < vertices.Length; i++)
            {
                var nextVertex = (i + 1) % 3;
                if (_lineIntersectValidator.Intersect(point1, point2, vertices[i], vertices[nextVertex]))
                {
                    return true;
                }
            }

            return IsInside(point1, triangle);
        }
    }
}