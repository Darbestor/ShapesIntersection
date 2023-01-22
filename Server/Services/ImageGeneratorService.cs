using ShapesFilter;
using ShapesFilter.Shapes;

namespace Server.Services;

public class ImageGeneratorService
{
    private readonly ImageBuilder _builder;

    public ImageGeneratorService(ImageBuilder builder)
    {
        _builder = builder ?? throw new ArgumentNullException(nameof(builder));
    }

    public Stream GetImage(IEnumerable<FilteredShape> shapes, int width, int height)
    {
        _builder.Width = width;
        _builder.Height = height;

        foreach (var shape in shapes)
            switch (shape.Shape)
            {
                case Line line:
                    _builder.AddLine(line, shape.Foreground);
                    break;
                case Circle circle:
                    _builder.AddCircle(circle, shape.Foreground);
                    break;
                case Rectangle rectangle:
                    _builder.AddRectangle(rectangle, shape.Foreground);
                    break;
                case Triangle triangle:
                    _builder.AddTriangle(triangle, shape.Foreground);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(shape.Shape), "Unknown shape");
            }

        return _builder.Build();
    }
}