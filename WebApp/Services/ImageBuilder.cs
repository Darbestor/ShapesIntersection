using System.Drawing;
using ShapesFilter.Shapes;
using Svg;
using Rectangle = ShapesFilter.Shapes.Rectangle;

namespace WebApp.Services;

public class ImageBuilder
{
    private static readonly SvgColourServer ForegroundColor = new(Color.Green);
    private static readonly SvgColourServer StrokeColor = new(Color.Black);
    private readonly SvgGroup _svgGroup;

    public ImageBuilder()
    {
        _svgGroup = new SvgGroup();
    }

    public int Width { get; set; } = 500;
    public int Height { get; set; } = 500;

    public void AddLine(Line line, bool foreground)
    {
        _svgGroup.Children.Add(new SvgLine
        {
            StartX = line.P1.X,
            StartY = line.P1.Y,
            EndX = line.P2.X,
            EndY = line.P2.Y,
            Stroke = foreground ? ForegroundColor : StrokeColor
        });
    }

    public void AddCircle(Circle circle, bool foreground)
    {
        _svgGroup.Children.Add(new SvgCircle
        {
            CenterX = circle.Center.X,
            CenterY = circle.Center.Y,
            Radius = circle.Radius,
            Fill = foreground ? ForegroundColor : null,
            Stroke = StrokeColor
        });
    }

    public void AddRectangle(Rectangle rectangle, bool foreground)
    {
        _svgGroup.Children.Add(new SvgRectangle
        {
            X = rectangle.TopLeft.X,
            Y = rectangle.TopLeft.Y,
            Width = Math.Abs(rectangle.BottomRight.X - rectangle.TopLeft.X),
            Height = Math.Abs(rectangle.BottomRight.Y - rectangle.TopLeft.Y),
            Fill = foreground ? ForegroundColor : null,
            Stroke = StrokeColor
        });
    }

    public void AddTriangle(Triangle triangle, bool foreground)
    {
        var points = new SvgPointCollection();
        var units = triangle.Vertices.Select(v => new SvgUnit[] { new(v.X), new(v.Y) }).SelectMany(x => x);
        points.AddRange(units);
        _svgGroup.Children.Add(new SvgPolygon
        {
            Points = points,
            Fill = foreground ? ForegroundColor : null,
            Stroke = StrokeColor
        });
    }

    public Stream Build()
    {
        var memoryStream = new MemoryStream();

        var svg = new SvgDocument
        {
            Width = Width,
            Height = Height,
            Fill = new SvgColourServer(Color.White)
        };
        svg.Children.Add(_svgGroup);
        svg.Write(memoryStream);
        memoryStream.Seek(0, SeekOrigin.Begin);
        return memoryStream;
    }
}