using System.Collections.Generic;
using ShapesFilter.Algorithms;
using ShapesFilter.Algorithms.LineIntersections;
using ShapesFilter.Algorithms.PointInside;
using ShapesFilter.Shapes;

namespace ShapesFilter.DI
{
    public static class StrategySelector
    {
        private static readonly Dictionary<(ShapeType, ShapeType), IIntersectValidator> _validators;

        static StrategySelector()
        {
            var lineCircle = new LineIntersectsCircle(new PointInsideCircle());
            var lineRectangle = new LineIntersectsRectangle();
            var lineTriangle = new LineIntersectsTriangle(new LineIntersectsLine(), new PointInsideTriangle());
            var circlePolygon = new CircleIntersectsPolygon(new LineIntersectsCircle(new PointInsideCircle()),
                new PointInsidePolygon());
            var rectangleCircle = new RectangleIntersectsCircle();
            _validators = new Dictionary<(ShapeType, ShapeType), IIntersectValidator>
            {
                { (ShapeType.Line, ShapeType.Line), new LineIntersectsLine() },
                { (ShapeType.Line, ShapeType.Circle), lineCircle },
                { (ShapeType.Circle, ShapeType.Line), lineCircle },
                { (ShapeType.Line, ShapeType.Rectangle), lineRectangle },
                { (ShapeType.Rectangle, ShapeType.Line), lineRectangle },
                { (ShapeType.Line, ShapeType.Triangle), lineTriangle },
                { (ShapeType.Triangle, ShapeType.Line), lineTriangle },
                { (ShapeType.Circle, ShapeType.Circle), new CircleIntersectsCircle() },
                { (ShapeType.Circle, ShapeType.Polygon), circlePolygon },
                { (ShapeType.Polygon, ShapeType.Circle), circlePolygon },
                {
                    (ShapeType.Polygon, ShapeType.Polygon),
                    new PolygonIntersectsPolygon(new RectangleIntersectsRectangle(), new LineIntersectsLine(),
                        new PointInsidePolygon())
                },
                { (ShapeType.Rectangle, ShapeType.Circle), rectangleCircle },
                { (ShapeType.Circle, ShapeType.Rectangle), rectangleCircle },
                { (ShapeType.Rectangle, ShapeType.Rectangle), new RectangleIntersectsRectangle() },
            };
        }


        public static IIntersectValidator GetStrategy(ShapeType shape1, ShapeType shape2)
        {
            return _validators.TryGetValue((shape1, shape2), out var v) ? v : null;
        }
    }
}