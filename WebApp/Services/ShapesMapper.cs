using ShapesFilter.Shapes;
using WebApp.Models;

namespace WebApp.Services;

public class ShapesMapper
{
    public List<IShape> MapModels(List<ShapeModel> models)
    {
        var mapped = new List<IShape>(models.Count);
        foreach (var model in models)
            switch (model)
            {
                case LineModel line:
                    mapped.Add(new Line(line.X1, line.Y1, line.X2, line.Y2));
                    break;
                case CircleModel circle:
                    mapped.Add(new Circle(new PointF(circle.X, circle.Y), circle.Radius));
                    break;
                case RectangleModel rectangle:
                    mapped.Add(new Rectangle(rectangle.Top, rectangle.Left, rectangle.Width, rectangle.Height));
                    break;
                case TriangleModel triangle:
                    mapped.Add(new Triangle(
                        new PointF(triangle.Point1.X, triangle.Point1.Y),
                        new PointF(triangle.Point2.X, triangle.Point2.Y),
                        new PointF(triangle.Point3.X, triangle.Point3.Y)));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(model), "Unknown model");
            }

        return mapped;
    }
}