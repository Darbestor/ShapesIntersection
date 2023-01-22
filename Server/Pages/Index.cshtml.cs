using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Server.Models;
using Server.Services;
using ShapesFilter;
using ShapesFilter.AlgorithmSelection;

namespace Server.Pages;

public class IndexModel : PageModel
{
    private const int ImageWidth = 700;
    private const int ImageHeight = 700;
    private const float ForegroundAreaThreshold = 10;

    private static List<ShapeModel> _testModels = new()
    {
        new LineModel { X1 = 213.6f, Y1 = 97, X2 = 327.6f, Y2 = 154 },
        new TriangleModel
        {
            Point1 = new Point { X = 250.3f, Y = 300.1f }, Point2 = new Point { X = 400.34f, Y = 200.34f },
            Point3 = new Point { X = 100.56f, Y = 150.78f }
        },
        new TriangleModel
        {
            Point1 = new Point { X = 340.1f, Y = 500.1f }, Point2 = new Point { X = 500.4f, Y = 600.34f },
            Point3 = new Point { X = 400.56f, Y = 450.78f }
        },
        new RectangleModel { Top = 121, Left = 58.6f, Width = 505, Height = 348 },
        new RectangleModel { Top = 65, Left = 78.6f, Width = 174, Height = 118 },
        new CircleModel { X = 241.1f, Y = 224.5f, Radius = 48 },
        new TriangleModel
        {
            Point1 = new Point { X = 50.3f, Y = 86.1f }, Point2 = new Point { X = 100.34f, Y = 82.34f },
            Point3 = new Point { X = 34.56f, Y = 56.78f }
        },
        new RectangleModel { Top = 192, Left = 293.6f, Width = 79, Height = 40 },
        new LineModel { X1 = 296.6f, Y1 = 393, X2 = 553.6f, Y2 = 280 },
        new CircleModel { X = 188.6f, Y = 346.5f, Radius = 48 },
        new LineModel { X1 = 655.6f, Y1 = 45, X2 = 665.6f, Y2 = 557 },
        new RectangleModel { Top = 281, Left = 334.6f, Width = 134, Height = 134 }
    };

    private readonly ShapesSessionRepository _shapesRepository;

    public IndexModel(ShapesSessionRepository shapesRepository)
    {
        _shapesRepository = shapesRepository;
        Shapes = _shapesRepository.GetShapes();
    }

    public List<ShapeModel> Shapes { get; set; }

    public void OnPostLine(LineModel line)
    {
        Shapes.Add(line);
        _shapesRepository.SetShapes(Shapes);
    }

    public void OnPostCircle(CircleModel circle)
    {
        Shapes.Add(circle);
        _shapesRepository.SetShapes(Shapes);
    }

    public void OnPostRectangle(RectangleModel rectangle)
    {
        Shapes.Add(rectangle);
        _shapesRepository.SetShapes(Shapes);
    }

    public void OnPostTriangle(TriangleModel triangle)
    {
        Shapes.Add(triangle);
        _shapesRepository.SetShapes(Shapes);
    }

    public void OnGetTestCase()
    {
        Shapes = _testModels;
        _shapesRepository.SetShapes(Shapes);
    }

    public void OnGetReset()
    {
        Shapes.Clear();
        _shapesRepository.ClearShapes();
    }

    public IActionResult OnGetGenerateSVG([FromServices] ImageGeneratorService imageGenerator,
        [FromServices] ShapesMapper shapesMapper)
    {
        var shapes = shapesMapper.MapModels(Shapes);
        var filter = new Filter(new DefaultAlgorithmsPipeline());
        var tested = filter.FilterForegroundShapes(shapes, ForegroundAreaThreshold);

        var imageStream = imageGenerator.GetImage(tested, ImageWidth, ImageHeight);
        var result = new FileStreamResult(imageStream, "image/svg+xml")
        {
            FileDownloadName = "Result.svg"
        };
        return result;
    }
}