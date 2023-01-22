using System;
using System.Collections.Generic;
using System.ComponentModel;
using ShapesFilter.Algorithms;
using ShapesFilter.Algorithms.LineIntersections;
using ShapesFilter.Algorithms.PointInside;
using ShapesFilter.Shapes;

namespace ShapesFilter.Strategy
{
    public enum ValidatorKey
    {
        LineLine,
        LineCircle,
        LineRectangle,
        LineTriangle,
        CircleCircle,
        CirclePolygon,
        PolygonPolygon,
        RectangleCircle,
        RectangleRectangle
    }

    /// <summary>
    /// Intersection strategy selector
    /// </summary>
    public static class StrategySelector
    {
        private static readonly Dictionary<ValidatorKey, IIntersectAlgorithm> _validators;

        static StrategySelector()
        {
            var lineCircle = new LineIntersectsCircle(new PointInsideCircle());
            var lineRectangle = new LineIntersectsRectangle();
            var lineTriangle = new LineIntersectsTriangle(new LineIntersectsLine(), new PointInsideTriangle());
            var circlePolygon = new CircleIntersectsPolygon(new LineIntersectsCircle(new PointInsideCircle()),
                new PointInsidePolygon());
            var rectangleCircle = new RectangleIntersectsCircle();
            _validators = new Dictionary<ValidatorKey, IIntersectAlgorithm>
            {
                { ValidatorKey.LineLine, new LineIntersectsLine() },
                { ValidatorKey.LineCircle, lineCircle },
                { ValidatorKey.LineRectangle, lineRectangle },
                { ValidatorKey.LineTriangle, lineTriangle },
                { ValidatorKey.CircleCircle, new CircleIntersectsCircle() },
                { ValidatorKey.CirclePolygon, circlePolygon },
                {
                    ValidatorKey.PolygonPolygon,
                    new PolygonIntersectsPolygon(new AABBIntersectsAABB(), new LineIntersectsLine(),
                        new PointInsidePolygon())
                },
                { ValidatorKey.RectangleCircle, rectangleCircle },
                { ValidatorKey.RectangleRectangle, new RectangleIntersectsRectangle(new AABBIntersectsAABB()) },
            };
        }

        /// <summary>
        /// Get intersection algorithm based on shape types
        /// </summary>
        /// <param name="shape1">Type of first shape</param>
        /// <param name="shape2">Type of second shape</param>
        /// <returns><see cref="IIntersectAlgorithm"/></returns>
        /// <exception cref="NotImplementedException">Intersection validator is not implemented for provided types</exception>
        /// <exception cref="ArgumentOutOfRangeException">Unknown types</exception>
        public static IIntersectAlgorithm GetStrategy(ShapeType shape1, ShapeType shape2)
        {
            if (!Enum.IsDefined(typeof(ShapeType), shape1))
                throw new InvalidEnumArgumentException(nameof(shape1), (int)shape1, typeof(ShapeType));
            if (!Enum.IsDefined(typeof(ShapeType), shape2))
                throw new InvalidEnumArgumentException(nameof(shape2), (int)shape2, typeof(ShapeType));
            switch (shape1)
            {
                case ShapeType.Line:
                    switch (shape2)
                    {
                        case ShapeType.Line:
                            return _validators[ValidatorKey.LineLine];
                        case ShapeType.Circle:
                            return _validators[ValidatorKey.LineCircle];
                        case ShapeType.Rectangle:
                            return _validators[ValidatorKey.LineRectangle];
                        case ShapeType.Polygon:
                            throw new NotImplementedException("Intersection check does not supported");
                        case ShapeType.Triangle:
                            return _validators[ValidatorKey.LineTriangle];
                        default:
                            throw new ArgumentOutOfRangeException(nameof(shape2), shape2, null);
                    }
                case ShapeType.Circle:
                    switch (shape2)
                    {
                        case ShapeType.Line:
                            return _validators[ValidatorKey.LineCircle];
                        case ShapeType.Circle:
                            return _validators[ValidatorKey.CircleCircle];
                        case ShapeType.Rectangle:
                            return _validators[ValidatorKey.RectangleCircle];
                        case ShapeType.Polygon:
                            return _validators[ValidatorKey.CirclePolygon];
                        case ShapeType.Triangle:
                            return _validators[ValidatorKey.CirclePolygon];
                        default:
                            throw new ArgumentOutOfRangeException(nameof(shape2), shape2, null);
                    }
                case ShapeType.Rectangle:
                    switch (shape2)
                    {
                        case ShapeType.Line:
                            return _validators[ValidatorKey.LineRectangle];
                        case ShapeType.Circle:
                            return _validators[ValidatorKey.RectangleCircle];
                        case ShapeType.Rectangle:
                            return _validators[ValidatorKey.RectangleRectangle];
                        case ShapeType.Polygon:
                            return _validators[ValidatorKey.PolygonPolygon];
                        case ShapeType.Triangle:
                            return _validators[ValidatorKey.PolygonPolygon];
                        default:
                            throw new ArgumentOutOfRangeException(nameof(shape2), shape2, null);
                    }
                case ShapeType.Polygon:
                    switch (shape2)
                    {
                        case ShapeType.Line:
                            throw new NotImplementedException("Intersection check does not supported");
                        case ShapeType.Circle:
                            return _validators[ValidatorKey.CirclePolygon];
                        case ShapeType.Rectangle:
                            return _validators[ValidatorKey.PolygonPolygon];
                        case ShapeType.Polygon:
                            return _validators[ValidatorKey.PolygonPolygon];
                        case ShapeType.Triangle:
                            return _validators[ValidatorKey.PolygonPolygon];
                        default:
                            throw new ArgumentOutOfRangeException(nameof(shape2), shape2, null);
                    }
                case ShapeType.Triangle:
                    switch (shape2)
                    {
                        case ShapeType.Line:
                            return _validators[ValidatorKey.LineTriangle];
                        case ShapeType.Circle:
                            return _validators[ValidatorKey.CirclePolygon];
                        case ShapeType.Rectangle:
                            return _validators[ValidatorKey.PolygonPolygon];
                        case ShapeType.Polygon:
                            return _validators[ValidatorKey.PolygonPolygon];
                        case ShapeType.Triangle:
                            return _validators[ValidatorKey.PolygonPolygon];
                        default:
                            throw new ArgumentOutOfRangeException(nameof(shape2), shape2, null);
                    }
                default:
                    throw new ArgumentOutOfRangeException(nameof(shape1), shape1, null);
            }
        }
    }
}