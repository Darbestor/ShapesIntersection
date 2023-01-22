using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Server.Models;
using Server.Services;
using ShapesFilter;
using ShapesFilter.Shapes;

namespace Server.Pages;

public class IndexModel : PageModel
{
    private const string ShapesKey = "shapes";

    private static List<IShape> _shapes = new()
    {
        new Line(213.6f, 97, 327.6f, 154),
        new Triangle(new PointF(250.3f, 300.1f), new PointF(400.34f, 200.34f), new PointF(100.56f, 150.78f)),
        new Triangle(new PointF(340.1f, 500.1f), new PointF(500.4f, 600.34f), new PointF(400.56f, 450.78f)),
        new Rectangle(121, 58.6f, 505, 348),
        new Rectangle(65, 78.6f, 174, 118),
        new Circle(new PointF(241.1f, 224.5f), 48),
        new Triangle(new PointF(50.3f, 86.1f), new PointF(100.34f, 82.34f), new PointF(34.56f, 56.78f)),
        new Rectangle(192, 293.6f, 79, 40),
        new Line(296.6f, 393, 553.6f, 280),
        new Circle(new PointF(188.6f, 346.5f), 48),
        new Line(655.6f, 45, 665.6f, 557),
        new Rectangle(281, 334.6f, 134, 134)
    };

    private readonly ILogger<IndexModel> _logger;

    private List<ShapeModel>? _shapeModels;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public List<ShapeModel> Shapes => GetSessionShapes();

    public void OnGet()
    {
        Console.WriteLine("Done!");
    }

    public void OnPostLine(LineModel line)
    {
        Shapes.Add(line);
        SetSessionShapes();
    }

    public void OnPostCircle(CircleModel circle)
    {
        Shapes.Add(circle);
        SetSessionShapes();
    }

    public void OnPostRectangle(RectangleModel rectangle)
    {
        Shapes.Add(rectangle);
        SetSessionShapes();
    }

    public void OnPostTriangle(TriangleModel triangle)
    {
        Shapes.Add(triangle);
        SetSessionShapes();
    }

    public IActionResult OnGetGenerateSVG([FromServices] ImageGeneratorService imageGenerator,
        [FromServices] ShapesMapper shapesMapper)
    {
        var shapes = shapesMapper.MapModels(Shapes);
        var filter = new Filter();
        var tested = filter.FilterForegroundShapes(shapes, 10);
        var t = tested.Where(x => x.Foreground).ToArray();

        var imageStream = imageGenerator.GetImage(tested, 1000, 1000);
        FileStreamResult result = new FileStreamResult(imageStream, "image/svg+xml")
        {
            FileDownloadName = "Filename.svg"
        };
        return result;
    }

    private void SetSessionShapes()
    {
        var serialized = JsonSerializer.Serialize(_shapeModels);
        HttpContext.Session.SetString(ShapesKey, serialized);
    }

    private List<ShapeModel> GetSessionShapes()
    {
        if (_shapeModels != null)
        {
            return _shapeModels;
        }

        _shapeModels = HttpContext.Session.TryGetValue(ShapesKey, out var raw)
            ? JsonSerializer.Deserialize<List<ShapeModel>>(raw)!
            : new List<ShapeModel>();
        return _shapeModels;
    }
}